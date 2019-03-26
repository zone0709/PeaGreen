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
    [Route("api/shift_register")]
    [ApiController]
    public class ShiftRegisterController : ControllerBase, IShiftRegisterController
    {
        readonly IShiftRegisterService shiftRegisterService;
        readonly HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK
        };
        static BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };
        public ShiftRegisterController(IShiftRegisterService shiftRegisterService)
        {
            this.shiftRegisterService = shiftRegisterService;
        }
        [HttpPost("")]
        public ActionResult Add(List<ShiftRegisterBasic> request)
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

                shiftRegisterService.RegistShift(request);
                response = BaseResponse<dynamic>.Get(false, ConstantManager.CreateSuccess("Shift Register :"), null, ResultEnum.Success);

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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Shift Register : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
        [HttpGet("")]
        public ActionResult Get()
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

                var data = shiftRegisterService.Get();
                var groupby = data.GroupBy(p => p.EmpName, p => p, (key, shift) => new { Name = key, Shift = shift.ToList() });
                response = BaseResponse<dynamic>.Get(false, ConstantManager.SUCCESS, groupby, ResultEnum.Success);

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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Shift Register : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
    }
}