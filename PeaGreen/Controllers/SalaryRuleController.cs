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
    
    [Route("api/salary_rule")]
    [ApiController]
    public class SalaryRuleController : ControllerBase, ISalaryRuleController
    {
        ISalaryRuleService salaryruleService;
        public SalaryRuleController(ISalaryRuleService salaryruleService)
        {
            this.salaryruleService = salaryruleService;
        }
        [HttpPost("")]
        public ActionResult Create(SalaryRuleBasic request)
        {
            salaryruleService.CreateSalaryRule(request);
            return Ok();
        }
        [HttpGet("")]
        public ActionResult Get([FromQuery]SalaryQueryRequest request)
        {
            var result = salaryruleService.GetSalaryRule(request);
            return Ok(result);
        }
    }
}