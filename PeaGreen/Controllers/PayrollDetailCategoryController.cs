using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataCore.Models;
using DataCore.Models.Service;
using DataCore.Models.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeaGreen.Controllers
{
    [Route("api/payroll_detail_category")]
    [ApiController]
    public class PayrollDetailCategoryController : ControllerBase, IPayrollDetailCategoryController
    {
        readonly ICheckFingerService checkFingerService;
        static BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };
        readonly IPayrollDetailCategoryService payrollCategoryService;
        public PayrollDetailCategoryController(IPayrollDetailCategoryService payrollCategoryService)
        {
            this.payrollCategoryService = payrollCategoryService;
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
                var data = payrollCategoryService.Get();
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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Template  : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
        }
    }
}