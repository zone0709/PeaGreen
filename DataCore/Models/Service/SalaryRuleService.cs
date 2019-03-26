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
    
    public class SalaryRuleService : BaseService<SalaryRule, SalaryRuleBasic>, ISalaryRuleService
    {
        public SalaryRuleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void CreateSalaryRule(SalaryRuleBasic request)
        {
            request.IsActive = true;
            Create(request);
        }

        public List<SalaryRuleResponse> GetSalaryRule(SalaryQueryRequest request)
        {
            var entity = GetAsNoTracking(p => p.Active == true && 
            (request.GroupId == null ||  p.SalaryRuleGroupMapping.Any(a => a.SalaryRuleGroupId == request.GroupId)));
            var result = entity.ProjectTo<SalaryRuleResponse>(Mapper.ConfigurationProvider).ToList();
            return result;
        }
    }
}
