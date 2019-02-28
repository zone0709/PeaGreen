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
    public interface IEmployeeGroupMappingService : IBaseService<EmployeeGroupMapping, EmpGroupMappingModel>
    {
        List<int> GetListEmp(int id);
    }
    public class EmployeeGroupMappingService : BaseService<EmployeeGroupMapping, EmpGroupMappingModel>, IEmployeeGroupMappingService
    {
        public EmployeeGroupMappingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<int> GetListEmp(int id)
        {
           var ListEmpId=  GetAsNoTracking(e => e.EmployeeGroupId == id).Select(p => p.EmployeeId).ToList();
            return ListEmpId;
        }
    }
}
