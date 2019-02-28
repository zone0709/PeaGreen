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
    public interface IPaySlipController
    {
        ActionResult<List<PaySlipEmpBasic>> Get();

        ActionResult AddEmp(PaySlipEmp request);
        ActionResult AddEmpGroup(PaySlipGroupEmp request);

        ActionResult Update(PaySlipBasic request);

        ActionResult DeActive(int id);
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PaySlipController : ControllerBase, IPaySlipController
    {
        IPaySlipService payslipService;
        public PaySlipController(IPaySlipService payslipService)
        {
            this.payslipService = payslipService;
        }
        [HttpPost("")]
        public ActionResult AddEmp(PaySlipEmp request)
        {
            payslipService.AddEmp(request);
            return Ok();
        }
        [HttpPost("group")]
        public ActionResult AddEmpGroup(PaySlipGroupEmp request)
        {
            payslipService.AddGroupEmp(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeActive(int id)
        {
            
            return Ok();
            throw new NotImplementedException();
        }

        [HttpGet, Route("")]
        public ActionResult<List<PaySlipEmpBasic>> Get()
        {
          return  Ok(new List<PaySlipEmpBasic>());
            throw new NotImplementedException();
        }

        [HttpPut, Route("")]
        public ActionResult Update(PaySlipBasic request)
        {
          return  Ok();
            throw new NotImplementedException();
        }
    }
}