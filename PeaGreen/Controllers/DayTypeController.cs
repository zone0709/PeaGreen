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
    public interface IDayTypeController
    {
        ActionResult<List<DayTypeBasic>> Get();
        ActionResult Create(DayTypeBasic request);
        ActionResult UpdateDate(DayTypeDateRequest request);
        ActionResult UpdateDayOfWeek(DayTypeDofWRequest request);
        ActionResult DeActive(DayTypeDeActiveRequest request);

    }
    [Route("api/[controller]")]
    [ApiController]
    public class DayTypeController : ControllerBase, IDayTypeController
    {
        IDayTypeService daytypeService;
        public DayTypeController(IDayTypeService dayTypeService)
        {
            this.daytypeService = dayTypeService;
        }
        [HttpPost,Route("")]
        public ActionResult Create(DayTypeBasic request)
        {
            Ok();
            throw new NotImplementedException();
        }
        [HttpDelete,Route("")]
        public ActionResult DeActive(DayTypeDeActiveRequest request)
        {
            Ok();
            throw new NotImplementedException();
        }

        [HttpGet("")]
        public ActionResult<List<DayTypeBasic>> Get()
        {
            var dayTypeQuery = daytypeService.Get();
            return Ok(dayTypeQuery.ToList());
        }
        [HttpPatch,Route("date")]
        public ActionResult UpdateDate(DayTypeDateRequest request)
        {
            Ok();
            throw new NotImplementedException();
        }
        [HttpPatch,Route("day")]
        public ActionResult UpdateDayOfWeek(DayTypeDofWRequest request)
        {
            Ok();
            throw new NotImplementedException();
        }
    }
}