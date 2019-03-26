using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DataCore.Models;
using DataCore.Models.Service;
using DataCore.Models.Utilities;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;


namespace PeaGreen.Controllers
{

    [Route("api/payroll_period")]
    [ApiController]
    public class PayrollPeriodController : ControllerBase, IPayrollPeriodController
    {
        IPayrollPeriodService payrollperiodService;
        readonly HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK
        };
        static BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };
        public PayrollPeriodController(IPayrollPeriodService payrollperiodService)
        {
            this.payrollperiodService = payrollperiodService;
        }
        [HttpPost("apply")]
        public ActionResult Apply(PayrollPeriodApply request)
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

                payrollperiodService.ApplyPeriod(request);
                response = BaseResponse<dynamic>.Get(true, ConstantManager.SUCCESS, null, ResultEnum.Success);
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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail(e.ToString()), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }

        [HttpPost("")]
        public ActionResult Create([FromBody]PayrollPeriodBasic request)
        {
            try
            {
                #region check model
                if (!ModelState.IsValid)
                {
                    var modelState = ModelState.FirstOrDefault();
                    var error = modelState.Value.Errors.FirstOrDefault().ErrorMessage;
                    throw ApiException.Get(false, error, ResultEnum.ModelError, HttpStatusCode.BadRequest);
                }
                #endregion

                payrollperiodService.CreatePeriod(request);
                response = BaseResponse<dynamic>.Get(true, ConstantManager.SUCCESS, null, ResultEnum.Success);
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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail(e.ToString()), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;

            //var a = ResponseMessage(httpResponseMessage);
            //return result;
            
        }
        [HttpGet("")]
        public ActionResult<List<PayrollPeriodResponse>> Get([FromQuery]int? empId )
        {
            try
            {
                #region check model
                if (!ModelState.IsValid)
                {
                    var modelState = ModelState.FirstOrDefault();
                    var error = modelState.Value.Errors.FirstOrDefault().ErrorMessage;
                    throw ApiException.Get(false, error, ResultEnum.ModelError, HttpStatusCode.BadRequest);
                }
                #endregion

                var data = payrollperiodService.Get(empId);
                if (data.Count <= 0)
                {
                    throw ApiException.Get(true, ConstantManager.NotFound(" Payroll Period "), ResultEnum.PeriodNotFound, HttpStatusCode.NotFound);
                }
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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail(e.ToString()), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
    }
}