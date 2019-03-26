using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DataCore.Models;
using DataCore.Models.Service;
using DataCore.Models.Utilities;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeaGreen.Controllers
{

    [Route("api/day_mode")]
    [ApiController]
    public class DayModeController : ControllerBase, IDayModeController
    {
        readonly IDayModeService dayModeService;
        readonly HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK
        };
        static BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };
        public DayModeController(IDayModeService dayModeService)
        {
            this.dayModeService = dayModeService;
        }
        [HttpPost, Route("")]
        public ActionResult Create(DayModeCreateRequest request)
        {
            
            try
            {
                #region check model
                //if (!ModelState.IsValid)
                //{
                //    var modelState = ModelState.FirstOrDefault();
                //    var error = modelState.Value.Errors.FirstOrDefault().ErrorMessage;
                //    throw ApiException.Get(false, error, ResultEnum.ModelError, HttpStatusCode.BadRequest);
                //}
                #endregion

                dayModeService.CreateDayMode(request);
                response = BaseResponse<dynamic>.Get(true, ConstantManager.CreateSuccess(""), null, ResultEnum.Success);

            }
            catch (ApiException e)
            {
                result.StatusCode = e.StatusCode;
                response = BaseResponse<dynamic>.Get(e.Success, e.ErrorMessage, null, e.ErrorStatus);
                result = new JsonResult(response);
            }
            catch (Exception e)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Day Mode : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
        [HttpDelete, Route("")]
        public ActionResult DeActive(DayModeDeActiveRequest request)
        {
            Ok();
            throw new NotImplementedException();
        }

        [HttpGet("")]
        public ActionResult<List<DayModeBasic>> Get()
        {
            try
            {
                #region check model
                //if (!ModelState.IsValid)
                //{
                //    var modelState = ModelState.FirstOrDefault();
                //    var error = modelState.Value.Errors.FirstOrDefault().ErrorMessage;
                //    throw ApiException.Get(false, error, ResultEnum.ModelError, HttpStatusCode.BadRequest);
                //}
                #endregion

                var data = dayModeService.Get();
                response = BaseResponse<dynamic>.Get(true, ConstantManager.SUCCESS, data, ResultEnum.Success);

            }
            catch (ApiException e)
            {
                result.StatusCode = e.StatusCode;
                response = BaseResponse<dynamic>.Get(e.Success, e.ErrorMessage, null, e.ErrorStatus);
                result = new JsonResult(response);
            }
            catch (Exception e)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Day Mode : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
        [HttpGet("day_of_weeks")]
        public ActionResult<List<DayofWeeks>> GetDoW()
        {
            try
            {
                #region check model
                //if (!ModelState.IsValid)
                //{
                //    var modelState = ModelState.FirstOrDefault();
                //    var error = modelState.Value.Errors.FirstOrDefault().ErrorMessage;
                //    throw ApiException.Get(false, error, ResultEnum.ModelError, HttpStatusCode.BadRequest);
                //}
                #endregion

                var data = dayModeService.GetDOW();
                response = BaseResponse<dynamic>.Get(true, ConstantManager.SUCCESS, data, ResultEnum.Success);

            }
            catch (ApiException e)
            {
                result.StatusCode = e.StatusCode;
                response = BaseResponse<dynamic>.Get(e.Success, e.ErrorMessage, null, e.ErrorStatus);
                result = new JsonResult(response);
            }
            catch (Exception e)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Day Mode : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }

        [HttpPatch, Route("date")]
        public ActionResult UpdateDate(DayModeDateRequest request)
        {
            Ok();
            throw new NotImplementedException();
        }
        [HttpPatch, Route("day")]
        public ActionResult UpdateDayOfWeek(DayModeDofWRequest request)
        {
            Ok();
            throw new NotImplementedException();
        }
    }
}