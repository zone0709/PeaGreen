using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeaGreen.Controllers
{
    public interface ITimeModeController
    {
        ActionResult<TimeModeBasic> Get();
        ActionResult Create(TimeModeBasic request);
        ActionResult Update(TimeModeBasic request);
        ActionResult DeActive(int id);
        ActionResult UpdateTime(TimeModeTimeRequest request);
    }
    [Route("api/[controller]")]
    [ApiController]
    public class TimeModeController : ControllerBase, ITimeModeController
    {
        [HttpPost,Route("")]
        public ActionResult Create(TimeModeBasic request)
        {
            Ok();
            throw new NotImplementedException();
        }

        [HttpDelete, Route("")]
        public ActionResult DeActive(int id)
        {
            Ok();
            throw new NotImplementedException();
        }

        [HttpGet, Route("")]
        public ActionResult<TimeModeBasic> Get()
        {
            Ok(new TimeModeBasic());
            throw new NotImplementedException();
        }

        [HttpPut, Route("")]
        public ActionResult Update(TimeModeBasic request)
        {
            Ok();
            throw new NotImplementedException();
        }

        [HttpPatch, Route("time")]
        public ActionResult UpdateTime(TimeModeTimeRequest request)
        {
            Ok();
            throw new NotImplementedException();
        }
    }
}