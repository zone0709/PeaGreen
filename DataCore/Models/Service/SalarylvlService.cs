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
    public interface ISalarylvlService : IBaseService<SalaryLevel,SalarylvlBasic>
    {
        IQueryable<SalarylvlBasic> Get();
    }
    public class SalarylvlService : BaseService<SalaryLevel, SalarylvlBasic>, ISalarylvlService
    {
        public SalarylvlService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IQueryable<SalarylvlBasic> Get()
        {
            var salaryQuery =  GetActiveAsNoTracking(s => s.IsActive == true);
            return salaryQuery.ProjectTo<SalarylvlBasic>(Mapper.ConfigurationProvider);
        }
    }
}
