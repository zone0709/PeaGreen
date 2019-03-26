using DataCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataCore;
using DataCore.Models;
using Microsoft.EntityFrameworkCore;
using org.mariuszgromada.math.mxparser;


namespace Tool01
{
    public class CalculatePaySlipService
    {
        public void RunAuto(DateTime fromday, DateTime today)
        {

            using (var db = new Reso_PeaContext())
            {
                // get ListPayrollPeriod 
                var listPeriod = db.PayrollPeriod.Where(p => p.FromDate >= fromday && p.ToDate <= today)
                    .Include(p => p.PaySlip)
                    .Include(p => p.PaySlipTemplate.TemplateDetailMapping).OrderByDescending(p => p.Id).Take(5)
                    .AsQueryable();

                foreach (var currentPeriod in listPeriod.ToList())
                {
                    // group PaySlip by empid
                    //var listGroupEmp = currentPeriod.PaySlip.
                    //    GroupBy(p => p.EmployeeId, p => p, (key, g)
                    //    => new { EmployeeId = key, ListPaySlip = g.ToList() });
                    foreach (var currentPaySlip in currentPeriod.PaySlip.ToList())
                    {
                        var payslip = db.PaySlip
                            .Include(p => p.Employee.EmployeeAttributeMapping)
                            .Include(p => p.PaySlipItem)
                            .Include(p => p.PayslipAttributeMapping).ThenInclude(a => a.Attribute)
                            .FirstOrDefault(p => p.Id == currentPaySlip.Id);

                        

                        var empSelected = payslip.Employee;
                        var finalTimeTotalResult = 0.0;
                        var totalValue = 0.0;
                        foreach (var currentPaySlipItem in payslip.PaySlipItem.ToList())
                        {
                            var payrollDetailSelected = db.PaySlipItem
                                .Include(p => p.PayrollDetail.PayrollDetailCategory)
                                .FirstOrDefault(p => p.Id == currentPaySlipItem.Id).PayrollDetail;
                            var value = 0.0;
                            switch (payrollDetailSelected.PayrollDetailCategoryId)
                            {

                                case (int)PayrollDetailCatetoryEnum.Basic: // Lương cơ bản
                                    {
                                        var listOfGroupSalaryRuleByTimeMode = db.SalaryRuleGroupMapping
                                            .Where(p => p.SalaryRuleGroupId == payrollDetailSelected.SalaryRuleGroupId)
                                            .Include(p => p.SalaryRule).Select(s => s.SalaryRule).GroupBy(s => s.TimeModeRuleId);
                                        //var salaryRuleGroupSelected = payrollDetailSelected.SalaryRuleGroup;
                                        //var listOfGroupSalaryRuleByTimeMode = salaryRuleGroupSelected.SalaryRuleGroupMapping.Select(s => s.SalaryRule).GroupBy(s => s.TimeModeRuleId);
                                        foreach (var groupSalaryRuleByTimemode in listOfGroupSalaryRuleByTimeMode)
                                        {
                                            double rateValueSelected = 1;
                                            var timeModeId = groupSalaryRuleByTimemode.Key;
                                            var timeTotalByTimeMode = new TimeSpan(0);
                                            var listSalaryHourActive = db.SalaryHour.Where(p => p.Active == true);
                                            if (listSalaryHourActive != null)
                                            {
                                                var SalaryHourOnOneEmployee = listSalaryHourActive
                                                    .Where(e => e.Date >= fromday && e.Date <= today
                                                        && e.TimeModeRuleId == timeModeId
                                                    //&& e.Status == (int)TimeSummaryEnum.Accept
                                                    && e.EmployeeId == empSelected.Id);
                                                if (SalaryHourOnOneEmployee != null && SalaryHourOnOneEmployee.Count() > 0)
                                                {
                                                    var durationTotal  = SalaryHourOnOneEmployee
                                                        .GroupBy(e => e.EmployeeId)
                                                        .ToList()
                                                        .Select(e =>
                                                new
                                                {
                                                    TimeTotal = e.Aggregate(new Double(), (sum, nextData) => (sum + nextData.Duration.GetValueOrDefault()))
                                                    //TimeTotal = e.Aggregate(new TimeSpan(), (sum, nextData)
                                                    //=> sum.Add(TimeSpan.FromHours(nextData.Duration.GetValueOrDefault()))),
                                                }).FirstOrDefault().TimeTotal;

                                                    timeTotalByTimeMode = TimeSpan.FromHours(durationTotal);
                                                }
                                            }
                                            foreach (var salaryRuleSelected in groupSalaryRuleByTimemode)
                                            {
                                                var durationMin = TimeSpan.FromHours(salaryRuleSelected.MinTimeDuration);
                                                var durationMax = TimeSpan.FromHours(salaryRuleSelected.MaxTimeDuration);
                                                if (timeTotalByTimeMode >= durationMin && timeTotalByTimeMode <= durationMax)
                                                {
                                                    timeTotalByTimeMode = TimeSpan.FromHours(salaryRuleSelected.Value.GetValueOrDefault());
                                                    rateValueSelected = salaryRuleSelected.Rate.GetValueOrDefault();
                                                }
                                            }
                                            finalTimeTotalResult += timeTotalByTimeMode.TotalHours * rateValueSelected;
                                        }
                                        value = finalTimeTotalResult * (double)empSelected.Salary;
                                        var payslipAttribute = db.PayslipAttribute.Where(p => p.Code.Equals("LCB")).FirstOrDefault();

                                        payslip.PayslipAttributeMapping.Where(p => p.AttributeId == payslipAttribute.Id).FirstOrDefault().Value = (int)value;

                                    }
                                    break;
                                case (int)PayrollDetailCatetoryEnum.Formula:
                                    {
                                        var formula = db.PayrollFormula.Where(p => p.Id == payrollDetailSelected.DefaultFormulaId.Value).FirstOrDefault();
                                        var expression = formula.Expression;
                                        var condition = formula.Condition;
                                        List<Attribute> empData = new List<Attribute>();

                                        var empAttrMapping = db.EmployeeAttributeMapping.Where(p => p.EmployeeId == empSelected.Id).Include(p => p.Attribute).AsQueryable();
                                        var listEmployeeAttribute = empAttrMapping.Select(s => new Attribute
                                        {
                                            Code = s.Attribute.Code,
                                            Value = s.Value != null ? s.Value.ToString() : s.Quality
                                        });
                                        var listPaySlipAttribute = payslip.PayslipAttributeMapping.Select(s => new Attribute
                                        {
                                            Code = s.Attribute.Code,
                                            Value = s.Value != null ? s.Value.ToString() : s.Quality
                                        });
                                        empData.AddRange(listEmployeeAttribute);
                                        empData.AddRange(listPaySlipAttribute);
                                        if (condition != null)
                                        {
                                            var singleConditionArray = condition.Split(';');
                                            List<ReturnData> listReturnData = new List<ReturnData>();

                                            foreach (var singleCondition in singleConditionArray)
                                            {
                                                //Xét 1 điều kiện lớn
                                                var index = singleCondition.IndexOf('=');
                                                var key = singleCondition.Substring(0, index);
                                                var keyCondition = singleCondition.Substring(index + 1);
                                                var returnData = new ReturnData
                                                {
                                                    Key = key,
                                                    KeyCondition = keyCondition,
                                                    Value = 0
                                                };
                                                listReturnData.Add(returnData);
                                            }
                                            foreach (var returnData in listReturnData)
                                            {
                                                returnData.Value = Helpers.processingSingleCondtion(returnData.KeyCondition, empData);
                                            }
                                            foreach (var data in listReturnData)
                                            {
                                                expression = expression.Replace(data.Key, data.Value.ToString());
                                            }
                                        }
                                        foreach (var item in empData)
                                        {
                                            if (item.Code.Equals("LCB"))
                                            {
                                                expression = expression.Replace(',', '.');
                                                expression = expression.Replace("LCB", item.Value);
                                            }
                                        }
                                        Expression a = new Expression(expression);
                                        if (!double.IsNaN(a.calculate()))
                                        {
                                            value = a.calculate();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Có lỗi trong việc tính toán ở công thức . Xin liên hệ với admin để được hỗ trợ");
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        value = payrollDetailSelected.Value.GetValueOrDefault();
                                    }
                                    break;
                            }
                            totalValue += value;
                            currentPaySlipItem.Value = value;
                            db.Entry(currentPaySlipItem).State = EntityState.Modified;
                        }
                        payslip.FinalPaid = totalValue;
                        db.Entry(payslip).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
        }

        
    }
}

