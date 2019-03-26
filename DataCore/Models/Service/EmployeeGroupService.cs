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
    public class EmployeeGroupService : BaseService<EmployeeGroup, EmployeeGroupBasic>, IEmployeeGroupService
    {
        public EmployeeGroupService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<EmployeeGroupBasic> GetGroup()
        {
            var result = GetAll().ToList();
            return result;
        }

        
    }
}
