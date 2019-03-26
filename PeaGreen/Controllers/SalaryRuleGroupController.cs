using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCore.Models.Service;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeaGreen.Controllers
{
    [Route("api/salary_rule_group")]
    [ApiController]
    public class SalaryRuleGroupController : ControllerBase, ISalaryRuleGroupController
    {
        ISalaryRuleGroupService salaryRuleGroupService;
        public SalaryRuleGroupController(ISalaryRuleGroupService salaryRuleGroupService)
        {
            this.salaryRuleGroupService = salaryRuleGroupService;
        }

        [HttpGet("")]
        public ActionResult<List<SalaryRuleGroupBasic>> Get()
        {
            var result = salaryRuleGroupService.Get();
            return Ok(result);
        }
    }
}