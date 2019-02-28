using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore.Models.Service
{   public interface IEmployeeJobMappingService : IBaseService<EmployeeJobMapping, EmployeeJobMappingViewModel>
    {
        List<int> GetByEmpId(int id);
    }
    public class EmployeeJobMappingService : BaseService<EmployeeJobMapping, EmployeeJobMappingViewModel>, IEmployeeJobMappingService
    {
        public EmployeeJobMappingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<int> GetByEmpId(int id)
        {
          return   GetActiveAsNoTracking(ej => ej.EmployeeId == id).Select(e => e.EmployeeRoleId.Value).ToList();
        }
    }
}
