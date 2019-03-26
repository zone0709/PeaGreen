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
    
    [Route("api/time_mode")]
    [ApiController]
    public class TimeModeController : ControllerBase, ITimeModeController
    {
        ITimeModeService timeModeService;
        public TimeModeController(ITimeModeService timeModeService)
        {
            this.timeModeService = timeModeService;
        }
        [HttpPost, Route("")]
        public ActionResult Create(TimeModeBasic request)
        {
            timeModeService.CreateTimeMode(request);
            return Ok();
        }

        [HttpDelete, Route("")]
        public ActionResult DeActive(int id)
        {
            Ok();
            throw new NotImplementedException();
        }

        [HttpGet, Route("")]
        public ActionResult<List<TimeModeBasic>> Get()
        {
           return Ok(timeModeService.GetTimeModes());
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