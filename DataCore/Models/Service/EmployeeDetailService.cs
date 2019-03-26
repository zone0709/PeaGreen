using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models.Service
{
    
    public class EmployeeDetailService : BaseService<Employee, EmployeeDetail>, IEmployeeDetailService
    {
        readonly IEmployeeJobMappingService EmployeeJobMappingService;
        readonly IEmployeeJobService EmployeeJobService;
        public EmployeeDetailService(IEmployeeJobMappingService employeeJobMappingService, IEmployeeJobService employeeJobService, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            EmployeeJobMappingService = employeeJobMappingService;
            EmployeeJobService = employeeJobService;
        }

        public async Task<EmployeeDetail> GetDetailById(int id)
        { 
            var EmpD = await FirstOrDefaultActiveAsync(e => e.Id == id && e.IsActive == true);
            var ListId = EmployeeJobMappingService.GetByEmpId(EmpD.Id);
            EmpD.RoleName = EmployeeJobService.GetRoleNameById(ListId);
            return EmpD;
        }
    }
}
