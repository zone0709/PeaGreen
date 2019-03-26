using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DataCore.Models;
using DataCore.Models.Entities;
using DataCore.Models.Service;
using DataCore.Models.Utilities;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyConnect.API.Identities;

namespace PeaGreen.Controllers
{
    
    [Route("api/employee")]
    [ApiController]
    
    public class EmployeeController : ControllerBase, IEmployeeController
    {
        static  IEmployeeService employeeService;
        //IEmployeeDetailService employeeDetailService;
        readonly HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK
        };
        static BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };

        public EmployeeController(IEmployeeService employeeService/*, IEmployeeDetailService employeeDetailService*/)
        {
            EmployeeController.employeeService = employeeService;
            //this.employeeDetailService = employeeDetailService;
        }

        //[HttpPost,Route("")]
        //public ActionResult Create(EmployeeBasic request)
        //{
        //    try
        //    {
        //        #region check model
        //        //if (!ModelState.IsValid)
        //        //{
        //        //    var modelState = ModelState.FirstOrDefault();
        //        //    var error = modelState.Value.Errors.FirstOrDefault().ErrorMessage;
        //        //    throw ApiException.Get(false, error, ResultEnum.ModelError, HttpStatusCode.BadRequest);
        //        //}
        //        #endregion
                
        //        //var data = employeeService.Get().ToList();
        //        response = BaseResponse<dynamic>.Get(true, ConstantManager.NOTIMPLEMENT, null, ResultEnum.Success);

        //    }
        //    catch (ApiException e)
        //    {
        //        result.StatusCode = e.StatusCode;
        //        response = BaseResponse<dynamic>.Get(e.Success, e.ErrorMessage, null, e.ErrorStatus);
        //        result = new JsonResult(response);
        //    }
        //    catch (Exception e)
        //    {
        //        result.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Employee  : ") + e.ToString(), null, ResultEnum.InternalError);
        //    }
        //    result = new JsonResult(response);
        //    return result;
           
        //}

        [HttpGet("")]
        //[BlockEmployee(Block = "ActiveUser",Except = "Administrator")]
        public ActionResult Get([FromQuery(Name ="id")]int? EmployeeId)
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
                if (EmployeeId.HasValue)
                {
                    var data = employeeService.Get(EmployeeId.Value);
                    response = BaseResponse<dynamic>.Get(true, ConstantManager.SUCCESS, data, ResultEnum.Success);
                }
                else
                {
                    var data = employeeService.Get().ToList();

                    response = BaseResponse<dynamic>.Get(true, ConstantManager.SUCCESS, data, ResultEnum.Success);
                }
               

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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Employee  : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
            
        }
        //[HttpGet("detail")]
        //public async Task<ActionResult<EmployeeDetail>> GetDetail([FromQuery]int id)
        //{
        //    var empDetailQ = employeeDetailService.GetDetailById(id);
        //    return Ok(await empDetailQ);
        //}

        [HttpPut, Route("")]
        public ActionResult Update(EmployeeBasic request)
        {
            return Ok();
        }
        [HttpPatch,Route("address")]
        public ActionResult UpdateAddress(AddressRequest request)
        {
            var update = new EmployeeUpdatePatch()
            {
                Address = request.Address,
                EmpId = request.EmpId
            };
            employeeService.UpdatePatch(update);
            return Ok();
        }

        //[HttpPatch,Route("brand")]
        //public ActionResult UpdateBrand(BrandRequest request)
        //{
        //    return Ok();
        //    throw new NotImplementedException();
        //}
        //[HttpPatch,Route("job")]
        //public ActionResult UpdateJob(JobRequest request)
        //{
        //    return Ok();
        //    throw new NotImplementedException();
        //}

        [HttpPatch, Route("name")]
        public ActionResult UpdateName(NameRequest request)
        {
            var update = new EmployeeUpdatePatch()
            {
                Name = request.Name,
                EmpId = request.EmpId
            };
            employeeService.UpdatePatch(update);
            return Ok();
        }

        [HttpPatch, Route("phone")]
        public ActionResult UpdatePhone(PhoneRequest request)
        {
            var update = new EmployeeUpdatePatch()
            {
                Phone = request.Phone,
                EmpId = request.EmpId
            };
            employeeService.UpdatePatch(update);
            return Ok();
        }

        //[HttpPatch, Route("sex")]
        //public ActionResult UpdateSex(SexRequest request)
        //{
        //    return Ok();
        //    throw new NotImplementedException();
        //}
    }
}