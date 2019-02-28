using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.Service
{
    public interface IPaySlipService : IBaseService<PaySlip, PaySlipBasic>
    {
        void AddEmp(PaySlipEmp model);
        void AddGroupEmp(PaySlipGroupEmp model);
        void DeleteEmp(PaySlipEmp model);
    }
    public class PaySlipService : BaseService<PaySlip, PaySlipBasic>, IPaySlipService
    {
        IEmployeeGroupMappingService empGroupMappingService;
        public PaySlipService(IEmployeeGroupMappingService empGroupMappingService, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.empGroupMappingService = empGroupMappingService;
        }

        public void AddEmp(PaySlipEmp model)
        {
            foreach (var item in model.EmpId)
            {
                var basicvm = new PaySlipBasic()
                {
                    EmployeeId = item,
                    PayrollPeriodId = model.Id,
                    IsActive = true
                };
                Create(basicvm);
            }
        }

        public void AddGroupEmp(PaySlipGroupEmp model)
        {
            var payslip = new PaySlipEmp();

            payslip.EmpId = empGroupMappingService.GetListEmp(model.GroupId);
            payslip.Id = model.Id;
            AddEmp(payslip);
            
        }

        public void DeleteEmp(PaySlipEmp model)
        {
            
        }
    }
}
