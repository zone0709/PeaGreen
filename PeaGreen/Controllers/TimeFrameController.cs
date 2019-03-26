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
    /// <summary>
    /// Tạo ca cho nhân viên đăng kí hoặc quản lí phân ca
    /// </summary>
    [Route("api/time_frame")]
    [ApiController]
    public class TimeFrameController : ControllerBase, ITimeFrameController
    {
        readonly ITimeFrameService timeFrameService;
        public TimeFrameController( ITimeFrameService timeFrameService)
        {
            this.timeFrameService = timeFrameService;
        }

        [HttpPost("")]
        public ActionResult Create(TimeFrameRequestCreate request)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
            BaseResponse<dynamic> response = new BaseResponse<dynamic>();
            JsonResult result = new JsonResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };

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

                 timeFrameService.Add(request);
                response = BaseResponse<dynamic>.Get(true, ConstantManager.CreateSuccess("Time frame :"), null, ResultEnum.Success);

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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Time frame : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
        [HttpGet("")]
        public ActionResult Get()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
            BaseResponse<dynamic> response = new BaseResponse<dynamic>();
            JsonResult result = new JsonResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };

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

                var data = timeFrameService.Get();
                response = BaseResponse<dynamic>.Get(true, ConstantManager.Success("Time frame :"), data, ResultEnum.Success);

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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Time frame : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
    }
}