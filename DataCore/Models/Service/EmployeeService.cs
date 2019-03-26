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

    public class EmployeeService : BaseService<Employee, EmployeeBasic>, IEmployeeService
    {
        readonly IMapper mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper/*, IEmployeeJobService employeeJobService*/) : base(unitOfWork, mapper)
        {
            this.mapper = mapper;
        }

        public  IQueryable<EmployeeBasic> Get(string email = null)
        {
            var EmpQuery = GetAsNoTracking(e => e.Active == true && (email == null || e.Email.Equals(email)));
            return EmpQuery.ProjectTo<EmployeeBasic>(Mapper.ConfigurationProvider);

        }

        public IQueryable<Employee> GetByGroupId(int id)
        {

            var result = GetAsNoTracking(p => p.EmployeeGroupId == id);
            return result;
        }

        public bool Add(UserBasic model)
        {
            var entity = new Employee();
            Mapper.Map(model, entity, typeof(UserBasic), typeof(Employee));
            entity.EmpEnrollNumber = Utils.GetCurrentDateTime().Ticks.ToString();
            entity.Active = true;
            entity.Status = (int)EmployeeStatusEnum.Active;
            entity = Create(entity);
            if (entity.Id != 0)
            {
                return true;
            }
            return false;
        }

        public void UpdatePatch(EmployeeUpdatePatch request)
        {
            var entity = FindEById(request.EmpId);
            if (request.Address != null)
            {
                entity.Address = request.Address;
            }
            if (request.Name != null)
            {
                entity.Name = request.Name;
            }
            if (request.Phone != null)
            {
                entity.Phone = request.Phone;
            }
            Update(entity);

        }

        public EmployeeDetail Get(int id)
        {
           var entity =  GetAsNoTracking(p => p.Active == true && p.Id == id).FirstOrDefault();
            var result = new EmployeeDetail(entity,mapper);
            return result;
        }
    }
}
