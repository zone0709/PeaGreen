using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.Service
{
    public interface IPayrollPeriodService : IBaseService<PayrollPeriod,PayrollPeriodViewModel>
    {
        void CreatePeriod(PayrollPeriodViewModel request);
    }
    public class PayrollPeriodService : BaseService<PayrollPeriod, PayrollPeriodViewModel>, IPayrollPeriodService
    {
        public PayrollPeriodService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void CreatePeriod(PayrollPeriodViewModel request)
        {
            request.IsActive = true;
            Create(request);
            
        }
    }
}
