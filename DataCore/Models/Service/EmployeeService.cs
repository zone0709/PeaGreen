using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore.Models.Service
{
    public interface IEmployeeService : IBaseService<Employee,EmployeeBasic>
    {
        IQueryable<EmployeeBasic> Get();
       
    }
    public class EmployeeService : BaseService<Employee, EmployeeBasic>, IEmployeeService
    {
        IEmployeeJobService empJobService;
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeJobService employeeJobService) : base(unitOfWork, mapper)
        {
            this.empJobService = employeeJobService;
        }

        public IQueryable<EmployeeBasic> Get()
        {
           var EmpQuery =  GetAsNoTracking(e => e.IsActive == true);
            return EmpQuery.ProjectTo<EmployeeBasic>(Mapper.ConfigurationProvider);
        }

        
    }
}
