using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore.Models.Service
{

    public class PayrollPeriodService : BaseService<PayrollPeriod, PayrollPeriodBasic>, IPayrollPeriodService
    {
        IPaySlipService paySlipService;
        IPaySlipTemplateService paySlipTemplateService;
        IEmployeeService employeeService;
        IPaySlipItemService paySlipItemService;
        IPaySlipAttributeService paySlipAttributeService;
        ITemplateDetailMappingService templateDetailMappingService;

        public PayrollPeriodService(
            IPaySlipAttributeService paySlipAttributeService,
            IEmployeeService employeeService,
            IPaySlipService paySlipService,
            IPaySlipTemplateService paySlipTemplateService,
            IPaySlipItemService paySlipItemService,
            ITemplateDetailMappingService templateDetailMappingService,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
            this.paySlipService = paySlipService;
            this.paySlipTemplateService = paySlipTemplateService;
            this.employeeService = employeeService;
            this.paySlipItemService = paySlipItemService;
            this.paySlipAttributeService = paySlipAttributeService;
            this.templateDetailMappingService = templateDetailMappingService;
        }

        public void ApplyPeriod(PayrollPeriodApply request)
        {
            var trans = UnitOfWork.CreateTransac();
            try
            {
                // get period by Id
                var entity =  FirstOrDefaultE(r => r.Id == request.Id);
                // get template
                var template = paySlipTemplateService.GetEById(entity.PaySlipTemplateId.Value);
                var payrolDetails = templateDetailMappingService.GetPayrollByTemplateId(template.Id);
                if (request.GroupId.HasValue)
                {
                    request.ListEmp = employeeService.GetByGroupId(request.GroupId.Value).Select(p => p.Id).ToList();
                }

                

                foreach (var empId in request.ListEmp)
                {
                    var employee = employeeService.FindEById(empId);
                    if(employee == null)
                    {
                        throw new Exception();
                    }

                    var paySlip = new PaySlip()
                    {
                        EmployeeId = empId,
                        PayrollPeriodId = entity.Id,
                        FromDate = entity.FromDate.Value,
                        ToDate = entity.ToDate.Value,
                    };

                    var listAllPaySlipAttribute = paySlipAttributeService.Get();
                    foreach (var attribute in listAllPaySlipAttribute)
                    {
                        switch (attribute.Code)
                        {
                            case "NBD":
                                paySlip.PayslipAttributeMapping.Add(new PayslipAttributeMapping
                                {
                                    PayslipId = paySlip.Id,
                                    AttributeId = attribute.Id,
                                    Value = entity.FromDate.Value.Day
                                });
                                break;
                            case "NKT":
                                paySlip.PayslipAttributeMapping.Add(new PayslipAttributeMapping
                                {
                                    PayslipId = paySlip.Id,
                                    AttributeId = attribute.Id,
                                    Value = entity.ToDate.Value.Day
                                });
                                break;
                            case "LCB":
                                paySlip.PayslipAttributeMapping.Add(new PayslipAttributeMapping
                                {
                                    PayslipId = paySlip.Id,
                                    AttributeId = attribute.Id,
                                    Value = 0
                                });
                                break;
                            case "TKL":
                                paySlip.PayslipAttributeMapping.Add(new PayslipAttributeMapping
                                {
                                    PayslipId = paySlip.Id,
                                    AttributeId = attribute.Id,
                                    Value = entity.ToDate.Value.Month
                                });
                                break;
                            default:
                                break;
                        }
                    }
                    // create PaySlip
                    var payslipId =  paySlipService.Add(paySlip);

                    // Create List PaySlipItem
                    if(payrolDetails.Count() == 0)
                    {
                        throw new Exception();
                    }
                    foreach (var payrollDetailSelected in payrolDetails)
                    {

                        
                        var paySlipItem = new PaySlipItem()
                        {
                            Name = payrollDetailSelected.Name,
                            PayrollDetailId = payrollDetailSelected.Id,
                            PaySlipId = payslipId
                        };
                        
                        paySlipItemService.Add(paySlipItem);

                    }
                    
                }
                trans.Commit();
                
            }
            catch (Exception e)
            {
                trans.Dispose();
                throw e ;
            }

        }

        public void CreatePeriod(PayrollPeriodBasic request)
        {
            request.IsActive = true;
            Create(request);
        }

        public List<PayrollPeriodResponse> Get(int? empId)
        {
            var listId = new List<int>();
            IQueryable<PayrollPeriod> entity = null;
            if (empId.HasValue)
            {
                listId = paySlipService.GetByEmpId(empId.Value);
                entity = GetActiveAsNoTracking(p => p.IsActive == true && (listId.Any(i => i == p.Id)));
            }
            else
            {
                entity = GetActiveAsNoTracking(p => p.IsActive == true && (listId.Count <= 0 || listId.Any(i => i == p.Id)));
            }

            var result = entity.ProjectTo<PayrollPeriodResponse>(Mapper.ConfigurationProvider).ToList();
            return result;
        }
    }
}
