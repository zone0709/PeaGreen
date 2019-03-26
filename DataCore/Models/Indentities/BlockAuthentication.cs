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

    public class BlockActionAttribute : Attribute, Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    {
        public bool AllowMultiple => true;
        protected HttpRequest _request;
        protected string _authorization;
        protected ClaimsPrincipal _claimPrincipal;
        public string block { get; set; }
        public string except { get; set; }

        static BaseResponse<dynamic> response = new BaseResponse<dynamic>();
        readonly JsonResult result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.OK
        };

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var blockList = new List<string>();
            var exceptList = new List<string>();
            _request = context.HttpContext.Request;

            _authorization = _request.Headers.FirstOrDefault(p => p.Key.Equals("Authorization")).Value.ToString();
            if (_authorization == null)
            {
                //context.Result = new AuthenticationFailureResult(ConstantManager.MES_REQUEST_DENY, _request, HttpStatusCode.NotAcceptable, (int)ResultEnum.BearerTokenNotFound);
                context.Result = result;
            }
            if (!string.IsNullOrEmpty(block))
            {
                blockList = block.Trim().Split(',').ToList();

            }
            if (!string.IsNullOrEmpty(except))
            {
                exceptList = except.Trim().Split(',').ToList();

            }
            //BlockCustom(actionContext, cancellationToken, blockList, exceptList);
            //var a = new HttpResponseMessage();
            //var reuslt = Task.FromResult<HttpResponseMessage>(a);
            //return reuslt;
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

    //public class AddHeaderAttribute : ResultFilterAttribute
    //{
    //    private readonly string _name;
    //    private readonly string _value;

    //    public AddHeaderAttribute(string name, string value)
    //    {
    //        _name = name;
    //        _value = value;
    //    }

    //    public override void OnResultExecuting(ResultExecutingContext context)
    //    {
    //        context.HttpContext.Response.Headers.Add(
    //            _name, new string[] { _value });
    //        base.OnResultExecuting(context);
    //    }
    //}
}