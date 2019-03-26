using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore.Models.Service
{
    public class SalaryRuleGroupService : BaseService<SalaryRuleGroup, SalaryRuleGroupBasic>, ISalaryRuleGroupService
    {
        public SalaryRuleGroupService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public List<SalaryRuleGroupBasic> Get()
        {
            var result = GetAll().ToList();
            return result;
        }
    }
}
