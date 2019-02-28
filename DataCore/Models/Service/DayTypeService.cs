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
    public interface IDayTypeService : IBaseService<DayType, DayTypeBasic>
    {
        IQueryable<DayTypeBasic> Get();
    }
    public class DayTypeService : BaseService<DayType, DayTypeBasic>, IDayTypeService
    {
        public DayTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IQueryable<DayTypeBasic> Get()
        {
           var daytypeQuery =  GetActiveAsNoTracking(d => d.IsActive == true);
            return daytypeQuery.ProjectTo<DayTypeBasic>(Mapper.ConfigurationProvider);
        }
    }
}
