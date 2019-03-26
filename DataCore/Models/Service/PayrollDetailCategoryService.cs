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
    public class PayrollDetailCategoryService : BaseService<PayrollDetailCategory, PayrollDetailCategoryBasic>, IPayrollDetailCategoryService
    {
        public PayrollDetailCategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<PayrollDetailCategoryBasic> Get()
        {
           return GetAsNoTracking(p => p.IsActive == true).ProjectTo<PayrollDetailCategoryBasic>(this.Mapper.ConfigurationProvider).ToList();
        }
    }
}
