using DataCore.Models;
using DataCore.Models.Indentities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataCore.Models.Utilities;
using DataCore.Models.Service;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace SkyConnect.API.Identities
{

    #region old
    //public class BlockMobieUser : Attribute, IAuthenticationFilter
    //{
    //    public bool AllowMultiple => true;
    //    BlockCustomAttribute Block = new BlockCustomAttribute();
    //    public string except { get; set; }

    //    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    //    {
    //        #region old
    //        //HttpRequestMessage request = context.Request;
    //        //// get token from request 

    //        //AuthenticationHeaderValue authorization = request.Headers.Authorization;
    //        //if (authorization == null)
    //        //{
    //        //    context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, request, HttpStatusCode.NotAcceptable, (int)ResultEnum.BearerTokenNotFound);
    //        //}
    //        //else
    //        //{
    //        //    var claimPrincipal = (ClaimsPrincipal)context.Principal;
    //        //    // get List role
    //        //    var role = claimPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
    //        //    //if (role.Contains(RoleTypeEnum.StoreManager.ToString()))
    //        //    //{ return; }
    //        //    if (!role.Contains(RoleTypeEnum.ActiveUser.ToString()) || (role.Contains(RoleTypeEnum.MobileUser.ToString()) && !role.Contains(RoleTypeEnum.StoreManager.ToString())))
    //        //    {
    //        //        context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, request, HttpStatusCode.NotAcceptable, (int)ResultEnum.RoleNotSupport);
    //        //    }
    //        //    else
    //        //    {
    //        //        return;
    //        //    }
    //        //}
    //        #endregion

    //        List<string> blockList = new List<string>();
    //        List<string> exceptList = new List<string>();
    //        blockList.Add(RoleTypeEnum.MobileUser.ToString());
    //        if (!string.IsNullOrEmpty(except))
    //        {
    //            exceptList = except.Trim().Split(',').ToList();
    //        }
    //        exceptList.Add(RoleTypeEnum.StoreManager.ToString());
    //        Block.BlockCustom(context, cancellationToken, blockList, exceptList);

    //    }

    //    public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    //    {
    //    }
    //}

    //public class BlockEmployee : Attribute, IAuthenticationFilter
    //{
    //    public bool AllowMultiple => true;
    //    BlockCustomAttribute Block = new BlockCustomAttribute();
    //    public string except { get; set; }

    //    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    //    {
    //        //HttpRequestMessage request = context.Request;

    //        //// get token from request 
    //        //AuthenticationHeaderValue authorization = request.Headers.Authorization;
    //        //if (authorization == null)
    //        //{
    //        //    context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, request, HttpStatusCode.NotAcceptable, (int)ResultEnum.BearerTokenNotFound);
    //        //}
    //        //else
    //        //{
    //        //    var claimPrincipal = (ClaimsPrincipal)context.Principal;
    //        //    // get List role
    //        //    var role = claimPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
    //        //    //if (role.Contains(RoleTypeEnum.StoreManager.ToString()))
    //        //    //{ return; }
    //        //    if (!role.Contains(RoleTypeEnum.ActiveUser.ToString()) || (role.Contains(RoleTypeEnum.Employee.ToString()) && !role.Contains(RoleTypeEnum.StoreManager.ToString())))
    //        //    {
    //        //        context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, request, HttpStatusCode.NotAcceptable, (int)ResultEnum.RoleNotSupport);
    //        //    }
    //        //    else
    //        //    {
    //        //        return;
    //        //    }
    //        //}

    //        List<string> blockList = new List<string>();
    //        List<string> exceptList = new List<string>();
    //        blockList.Add(RoleTypeEnum.Employee.ToString());
    //        if (!string.IsNullOrEmpty(except))
    //        {
    //            exceptList = except.Trim().Split(',').ToList();
    //        }
    //        exceptList.Add(RoleTypeEnum.StoreManager.ToString());
    //        Block.BlockCustom(context, cancellationToken, blockList, exceptList);
    //    }

    //    public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    //    {
    //    }
    //}

    //#region old
    ////public class BlockActive : Attribute, IAuthenticationFilter
    ////{
    ////    public bool AllowMultiple => true;
    ////    //protected HttpRequestMessage _request;
    ////    //protected AuthenticationHeaderValue _authorization;
    ////    //protected ClaimsPrincipal _claimPrincipal;
    ////    protected BlockAttribute BlockAttribute = new BlockAttribute();
    ////    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    ////    {
    ////        //_request = context.Request;
    ////        //// get token from request 
    ////        //_authorization = _request.Headers.Authorization;
    ////        //if (_authorization == null)
    ////        //{
    ////        //    context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, _request, HttpStatusCode.NotAcceptable, (int)ResultEnum.BearerTokenNotFound);
    ////        //}
    ////        //else
    ////        //{
    ////        //    _claimPrincipal = (ClaimsPrincipal)context.Principal;
    ////        //    // get List role
    ////        //    var role = _claimPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
    ////        //    if (!role.Contains(RoleTypeEnum.ActiveUser.ToString()))
    ////        //    {
    ////        //        context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, _request, HttpStatusCode.NotAcceptable, (int)ResultEnum.RoleNotSupport);
    ////        //    }
    ////        //    else
    ////        //    {
    ////        //        return;
    ////        //    }
    ////        //}
    ////        var attribute = new List<string>();
    ////        BlockAttribute.BlockCustom(context, cancellationToken, attribute);
    ////    }

    ////    public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    ////    {
    ////    }




    ////}
    //#endregion 
    //public interface IBlockCustomAttribute
    //{
    //    void BlockCustom(HttpAuthenticationContext context, CancellationToken cancellationToken, List<string> attribute, List<string> except);
    //}
    //public class BlockCustomAttribute : Attribute, IAuthenticationFilter, IBlockCustomAttribute
    //{
    //    public bool AllowMultiple => true;
    //    protected HttpRequestMessage _request;
    //    protected AuthenticationHeaderValue _authorization;
    //    protected ClaimsPrincipal _claimPrincipal;
    //    public string block { get; set; }
    //    public string except { get; set; }
    //    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    //    {
    //        var blockList = new List<string>();
    //        var exceptList = new List<string>();
    //        if (!string.IsNullOrEmpty(block))
    //        {
    //            blockList = block.Trim().Split(',').ToList();

    //        }
    //        if (!string.IsNullOrEmpty(except))
    //        {
    //            exceptList = except.Trim().Split(',').ToList();

    //        }
    //        BlockCustom(context, cancellationToken, blockList, exceptList);

    //    }

    //    public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    //    {

    //    }

    //    public void BlockCustom(HttpAuthenticationContext context, CancellationToken cancellationToken, List<string> blockList, List<string> exceptList)
    //    {
    //        _request = context.Request;
    //        // get token from request 
    //        _authorization = _request.Headers.Authorization;
    //        if (_authorization == null)
    //        {
    //            context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, _request, HttpStatusCode.NotAcceptable, (int)ResultEnum.BearerTokenNotFound);
    //        }
    //        else
    //        {
    //            _claimPrincipal = (ClaimsPrincipal)context.Principal;
    //            // get List role
    //            var role = _claimPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
    //            if (!role.Contains(RoleTypeEnum.ActiveUser.ToString()))
    //            {
    //                context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_NOT_ACTIVE, _request, HttpStatusCode.NotAcceptable, (int)ResultEnum.NotActive);
    //            }
    //            foreach (var e in exceptList)
    //            {
    //                if (role.Contains(e.ToString()))
    //                {
    //                    return;
    //                }
    //            }

    //            foreach (var item in blockList)
    //            {
    //                var a = (RoleTypeEnum[])Enum.GetValues(typeof(RoleTypeEnum));
    //                var check = a.FirstOrDefault(e => e.ToString().Contains(item)).ToString();
    //                if (check == null)
    //                {
    //                    context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_ROLE_WRONG, _request, HttpStatusCode.BadRequest, (int)ResultEnum.AttributeWrong);
    //                }
    //                if (role.Contains(item))
    //                {
    //                    context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, _request, HttpStatusCode.NotAcceptable, (int)ResultEnum.RoleNotSupport);
    //                }
    //            }

    //            return;

    //        }
    //    }


    //}
    #endregion

    public class BlockCustomAttribute : Attribute, IActionFilter
    {
        public bool AllowMultiple => true;
        protected HttpRequest _request;
        protected string _authorization;
        public string Block { get; set; }
        public string Except { get; set; }

        readonly static BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        readonly JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };

        public void OnActionExecuting(ActionExecutingContext context)
        {

            try
            {
                var blockList = new List<string>();
                var exceptList = new List<string>();
                if (!string.IsNullOrEmpty(Block))
                {
                    blockList = Block.Trim().Split(',').ToList();

                }
                if (!string.IsNullOrEmpty(Except))
                {
                    exceptList = Except.Trim().Split(',').ToList();

                }
                _request = context.HttpContext.Request;

                _authorization = _request.Headers.FirstOrDefault(p => p.Key.Equals("Authorization")).Value.ToString();
                if (_authorization == null || string.IsNullOrEmpty(_authorization))
                {
                    throw ApiException.Get(false, ConstantManager.MES_AUTHORIZATION_NOT_FOUND, ResultEnum.AuthorizationNotFound, HttpStatusCode.BadRequest);
                }
                else
                {
                    var tokenJWT = Utils.DecodeJwtToken(_authorization);
                    // get List role
                    var role = tokenJWT.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();
                    if (!role.Contains(RoleTypeEnum.ActiveUser.ToString()))
                    {
                        throw ApiException.Get(false, ConstantManager.MES_NOT_ACTIVE, ResultEnum.NotActive, HttpStatusCode.NotAcceptable);

                    }
                    foreach (var e in exceptList)
                    {
                        if (role.Contains(e.ToString()))
                        {
                            return;
                        }
                    }

                    foreach (var item in blockList)
                    {
                        var a = (RoleTypeEnum[])Enum.GetValues(typeof(RoleTypeEnum));
                        var check = a.FirstOrDefault(e => e.ToString().Contains(item)).ToString();
                        if (check == null)
                        {
                            throw ApiException.Get(false, ConstantManager.MES_ROLE_WRONG, ResultEnum.AttributeWrong, HttpStatusCode.BadRequest);

                        }
                        if (role.Contains(item))
                        {
                            throw ApiException.Get(false, ConstantManager.MES_REQUEST_DENY, ResultEnum.RoleNotSupport, HttpStatusCode.NotAcceptable);
                        }
                    }
                    return;

                }

            }
            catch (ApiException e)
            {
                result.StatusCode = e.StatusCode;
                result.Value = BaseResponse<dynamic>.Get(e.Success, e.ErrorMessage, null, e.ErrorStatus);

            }
            catch (Exception e)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                result.Value = BaseResponse<dynamic>.Get(false, ConstantManager.Fail(" Authentication   : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            context.Result = result;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        //public void BlockCustom(HttpActionContext context, CancellationToken cancellationToken, List<string> blockList, List<string> exceptList)
        //{
        //    _request = context.Request;
        //    // get token from request 
        //    _authorization = _request.Headers.Authorization;
        //    if (_authorization == null)
        //    {
        //        context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, _request, HttpStatusCode.NotAcceptable, (int)ResultEnum.BearerTokenNotFound);
        //    }
        //    else
        //    {
        //        _claimPrincipal = (ClaimsPrincipal)context.Principal;
        //        // get List role
        //        var role = _claimPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
        //        if (!role.Contains(RoleTypeEnum.ActiveUser.ToString()))
        //        {
        //            context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_NOT_ACTIVE, _request, HttpStatusCode.NotAcceptable, (int)ResultEnum.NotActive);
        //        }
        //        foreach (var e in exceptList)
        //        {
        //            if (role.Contains(e.ToString()))
        //            {
        //                return;
        //            }
        //        }

        //        foreach (var item in blockList)
        //        {
        //            var a = (RoleTypeEnum[])Enum.GetValues(typeof(RoleTypeEnum));
        //            var check = a.FirstOrDefault(e => e.ToString().Contains(item)).ToString();
        //            if (check == null)
        //            {
        //                context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_ROLE_WRONG, _request, HttpStatusCode.BadRequest, (int)ResultEnum.AttributeWrong);
        //            }
        //            if (role.Contains(item))
        //            {
        //                context.ErrorResult = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, _request, HttpStatusCode.NotAcceptable, (int)ResultEnum.RoleNotSupport);
        //            }
        //        }

        //        return;

        //    }
        //}
    }
    public interface IBlockEmployeeAtrribute
    {

    }
    public class BlockEmployeeAttribute : Attribute, IActionFilter, IBlockEmployeeAtrribute
    {
        public bool AllowMultiple => true;
        protected HttpRequest _request;
        protected string _authorization;
        public string Block { get; set; }
        public string Except { get; set; }
        protected IEmployeeService employeeService;

        readonly static BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        readonly JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                employeeService = context.HttpContext.RequestServices.GetService<IEmployeeService>();
                var blockList = new List<string>();
                var exceptList = new List<string>();
                if (!string.IsNullOrEmpty(Block))
                {
                    blockList = Block.Trim().Split(',').ToList();

                }
                if (!string.IsNullOrEmpty(Except))
                {
                    exceptList = Except.Trim().Split(',').ToList();

                }
                _request = context.HttpContext.Request;
                var query = _request.Query;

                _authorization = _request.Headers.FirstOrDefault(p => p.Key.Equals("Authorization")).Value.ToString();
                if (_authorization == null || string.IsNullOrEmpty(_authorization))
                {
                    throw ApiException.Get(false, ConstantManager.MES_AUTHORIZATION_NOT_FOUND, ResultEnum.AuthorizationNotFound, HttpStatusCode.BadRequest);
                }
                else
                {
                    var tokenJWT = Utils.DecodeJwtToken(_authorization);
                    // get List role
                    var role = tokenJWT.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();
                    var unique = tokenJWT.Claims.Where(c => c.Type == "unique_name").FirstOrDefault().Value.ToString();
                    var email = unique.Split('-')[0];
                    var emp = employeeService.Get(email).FirstOrDefault();
                    if (!role.Contains(RoleTypeEnum.ActiveUser.ToString()))
                    {
                        throw ApiException.Get(false, ConstantManager.MES_NOT_ACTIVE, ResultEnum.NotActive, HttpStatusCode.NotAcceptable);

                    }
                    if (!role.Contains(RoleTypeEnum.Administrator.ToString()))
                    {
                        if (query.Count() == 0)
                        {
                            throw ApiException.Get(false, ConstantManager.MES_REQUEST_DENY, ResultEnum.NotAcceptable, HttpStatusCode.NotAcceptable);
                        }
                        else
                        {
                            var id = query.FirstOrDefault(p => p.Key.Equals("id")).Value;
                            if(id != emp.Id)
                            {
                                throw ApiException.Get(false, ConstantManager.MES_REQUEST_DENY, ResultEnum.NotAcceptable, HttpStatusCode.NotAcceptable);
                            }
                        }
                    }
                    //foreach (var e in exceptList)
                    //{
                    //    if (role.Contains(e.ToString()))
                    //    {
                    //        return;
                    //    }
                    //}

                    //foreach (var item in blockList)
                    //{
                    //    var a = (RoleTypeEnum[])Enum.GetValues(typeof(RoleTypeEnum));
                    //    var check = a.FirstOrDefault(e => e.ToString().Contains(item)).ToString();
                    //    if (check == null)
                    //    {
                    //        throw ApiException.Get(false, ConstantManager.MES_ROLE_WRONG, ResultEnum.AttributeWrong, HttpStatusCode.BadRequest);

                    //    }
                    //    if (role.Contains(item))
                    //    {
                    //        throw ApiException.Get(false, ConstantManager.MES_REQUEST_DENY, ResultEnum.RoleNotSupport, HttpStatusCode.NotAcceptable);
                    //    }
                    //}
                    return;

                }

            }
            catch (ApiException e)
            {
                result.StatusCode = e.StatusCode;
                result.Value = BaseResponse<dynamic>.Get(e.Success, e.ErrorMessage, null, e.ErrorStatus);

            }
            catch (Exception e)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                result.Value = BaseResponse<dynamic>.Get(false, ConstantManager.Fail(" Authentication   : ") + e.ToString(), null, ResultEnum.InternalError);
            }
            context.Result = result;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

    }
}