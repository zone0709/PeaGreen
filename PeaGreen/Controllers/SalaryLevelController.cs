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
    public interface ISalaryLevelController
    {
        ActionResult<List<SalarylvlBasic>> Get();
        ActionResult Create(SalarylvlBasic request);
        ActionResult UpdateName(SalarylvlNameRequest request);
        ActionResult UpdateValue(ValueRequest request);
        ActionResult DeActive(DeActiveRequest request);
    }
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryLevelController : ControllerBase, ISalaryLevelController
    {
        ISalarylvlService salarylvlService;
        public SalaryLevelController(ISalarylvlService salarylvlService)
        {
            this.salarylvlService = salarylvlService;
        }

        [HttpPost,Route("")]
        public ActionResult Create(SalarylvlBasic request)
        {
            return Ok();
            throw new NotImplementedException();
        }

        [HttpDelete, Route("")]
        public ActionResult DeActive(DeActiveRequest request)
        {
            return Ok();
            throw new NotImplementedException();
        }

        [HttpGet("")]
        public ActionResult<List<SalarylvlBasic>> Get()
        {
            var salaryQuery = salarylvlService.Get();
            return Ok(salaryQuery.ToList());
        }

        [HttpPatch,Route("name")]
        public ActionResult UpdateName(SalarylvlNameRequest request)
        {
            return Ok();
            throw new NotImplementedException();
        }

        [HttpPatch,Route("value")]
        public ActionResult UpdateValue(ValueRequest request)
        {
            return Ok();
            throw new NotImplementedException();
        }
    }
}