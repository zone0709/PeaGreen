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
using Microsoft.Extensions.Options;

namespace PeaGreen.Controllers
{
    
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private readonly UserConfiguration _userConfiguration;
        readonly IUserService userService;
        private readonly string brandToken;
        private readonly string regisAdminToken;
        private readonly string AUDIENCE;
        private readonly string ISSUER;
        private readonly string SECRETKEY;
        static BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };
        public UserController(IOptions<UserConfiguration> userConfiguration, IUserService userService)
        {
            this._userConfiguration = userConfiguration.Value;
            this.brandToken = _userConfiguration.BrandToken;
            this.regisAdminToken = _userConfiguration.RegisAdminToken;
            this.AUDIENCE = _userConfiguration.AUDIENCE;
            this.ISSUER = _userConfiguration.ISSUER;
            this.SECRETKEY = _userConfiguration.SECRETKEY;
            this.userService = userService;
        }
        [HttpPost,Route("login")]
        public async  Task<ActionResult<UserResponse>> Login(UserLoginRequest request)
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
                var data = await userService.Login(brandToken, request);
                
                response = BaseResponse<dynamic>.Get(true, ConstantManager.Success("Login"), data, ResultEnum.Success);

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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Login : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
           
        }

        [HttpPost, Route("register")]
        public ActionResult Register(UserBasic request)
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
                var task = userService.Register(brandToken, request);
                task.Wait();

                response = BaseResponse<dynamic>.Get(true, ConstantManager.Success("Register"), null, ResultEnum.Success);

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
                response = BaseResponse<dynamic>.Get(false, ConstantManager.Fail("Register : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            result = new JsonResult(response);
            return result;
           
            // create asp user , employee , membership , account 
           
        }

        [HttpPost, Route("reset")]
        public ActionResult ResetPassword([FromBody]string email)
        {
            Ok();
            throw new NotImplementedException();
        }
    }
}