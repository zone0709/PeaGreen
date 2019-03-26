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
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase, IAttendanceController
    {
        readonly IAttendanceService attendanceService;
        HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK
        };
        static  BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };
        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }
        [HttpPost("accept")]
        public ActionResult Accept(AttentdenceAcceptRequest request)
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

                attendanceService.Accept(request);
                response = BaseResponse<dynamic>.Get(true, ConstantManager.CreateSuccess("Attendance :"), null, ResultEnum.Success);

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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Attendance : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }

        /// <summary>
        /// sắp ca cho nhân viên
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        [HttpPost("")]
        public ActionResult Add(List<AttentdenceRequest> requests)
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

                attendanceService.Add(requests);
                response = BaseResponse<dynamic>.Get(true, ConstantManager.CreateSuccess("Attendance :"), null, ResultEnum.Success);

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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Attendance : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
        [HttpGet("")]
        public ActionResult Get([FromQuery]AttendanceQueryRequest request)
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

                var data = attendanceService.Get(request);
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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Attendance : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
        [HttpGet("status")]
        public ActionResult GetStatus([FromQuery]AttendanceQueryRequest request)
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

                var data = attendanceService.GetStatus(request);
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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Attendance : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
    }
}