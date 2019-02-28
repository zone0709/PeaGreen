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
    public interface IEmployeeJobService : IBaseService<EmployeeJob, EmployeeJobBasic>
    {
        IQueryable<EmployeeJobBasic> Get();
        List<string> GetRoleNameById(List<int> listid);
    }
    public class EmployeeJobService : BaseService<EmployeeJob, EmployeeJobBasic>, IEmployeeJobService
    {
        public EmployeeJobService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IQueryable<EmployeeJobBasic> Get()
        {
            var empJobQuery = GetActiveAsNoTracking(e => e.IsActive == true);
            return empJobQuery.ProjectTo<EmployeeJobBasic>(Mapper.ConfigurationProvider);
        }

        public List<string> GetRoleNameById(List<int> listid)
        {
            return GetActiveAsNoTracking(e => e.IsActive == true
           && listid.Any(i => i == e.Id))
            .Select(em => em.RoleName).ToList();
        }
    }
}
