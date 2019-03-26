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
    
    public class PayrollDetailService : BaseService<PayrollDetail, PayrollDetailBasic>, IPayrollDetailService
    {
        public PayrollDetailService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void CreatePayrollDetail(PayrollDetailBasic model)
        {
            model.IsActive = true;
            Create(model);
        }

        public IQueryable<PayrollDetail> GetPayrollDetail()
        {
            var payrollQ = GetAsNoTracking(p => p.Active == true);
           
            return payrollQ;
        }
        
    }
}
