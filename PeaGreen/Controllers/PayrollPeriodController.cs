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
    public interface IPayrollPeriodController
    {
        ActionResult Create(PayrollPeriodViewModel request);
    }
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollPeriodController : ControllerBase, IPayrollPeriodController
    {
        IPayrollPeriodService payrollperiodService;
        public PayrollPeriodController(IPayrollPeriodService payrollperiodService)
        {
            this.payrollperiodService = payrollperiodService;
        }
        [HttpPost("")]
        public ActionResult Create([FromBody]PayrollPeriodViewModel request)
        {
            payrollperiodService.CreatePeriod(request);
            return Ok();
        }
    }
}