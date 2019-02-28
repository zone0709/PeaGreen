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
    public interface IEmployeeJobController
    {
        ActionResult<EmployeeJobBasic> Get();
    }

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeJobController : ControllerBase, IEmployeeJobController
    {
        IEmployeeJobService empJobService;
        public EmployeeJobController(IEmployeeJobService empJobService)
        {
            this.empJobService = empJobService;
        }
        [HttpGet("")]
        public ActionResult<EmployeeJobBasic> Get()
        {
            var empJobQuery = empJobService.Get();
            return Ok(empJobQuery.ToList());
        }
    }
}