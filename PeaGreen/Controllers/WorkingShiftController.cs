using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeaGreen.Controllers
{
    public interface IWorkingShiftController
    {
        ActionResult<WorkingShiftBasic> Get();
        ActionResult Create(WorkingShiftBasic request);
        ActionResult Update(WorkingShiftBasic request);
        ActionResult DeActive(int id);

    }
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingShiftController : ControllerBase, IWorkingShiftController
    {
        [HttpPost,Route("")]
        public ActionResult Create(WorkingShiftBasic request)
        {
            Ok();
            // create workshift , workshift mapping with employee
            throw new NotImplementedException();
        }
        [HttpDelete, Route("")]
        public ActionResult DeActive(int id)
        {
            Ok();
            throw new NotImplementedException();
        }
        [HttpGet, Route("")]
        public ActionResult<WorkingShiftBasic> Get()
        {
            Ok(new WorkingShiftBasic());
            throw new NotImplementedException();
        }
        [HttpPut, Route("")]
        public ActionResult Update(WorkingShiftBasic request)
        {
            Ok();
            throw new NotImplementedException();
        }
    }
}