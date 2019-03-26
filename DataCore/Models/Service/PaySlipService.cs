using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore.Models.Service
{

    public class PaySlipService : BaseService<PaySlip, PaySlipBasic>, IPaySlipService
    {
        IEmployeeService empService;
        public PaySlipService(IEmployeeService empService, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.empService = empService;
        }

        public int Add(PaySlip entity)
        {
            entity.Active = true;
            var result = Create(entity);
            return result.Id;
        }

        public void AddListEmp(PaySlipEmp model)
        {
            foreach (var item in model.EmpId)
            {
                var basicvm = new PaySlip()
                {
                    EmployeeId = item,
                    PayrollPeriodId = model.Id,
                };
                Add(basicvm);
            }
        }

        public void AddGroupEmp(PaySlipGroupEmp model)
        {
            var payslip = new PaySlipEmp();

            payslip.EmpId = empService.GetByGroupId(model.GroupId).Select(p => p.Id).ToList();
            payslip.Id = model.Id;
            AddListEmp(payslip);

        }

        public void DeleteEmp(PaySlipEmp model)
        {

        }

        public List<int> GetByEmpId(int empId)
        {
            var entity = GetActiveAsNoTracking(p => p.EmployeeId == empId);
            var result = entity.Select(a => a.PayrollPeriodId.Value).ToList();
            return result;
        }
    }
}
