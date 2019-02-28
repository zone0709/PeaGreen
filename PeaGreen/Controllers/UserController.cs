using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeaGreen.Controllers
{
    public interface IUserController
    {
        ActionResult<UserResponse> Login(UserLoginRequest request);
        ActionResult Register(UserBasic request);
        ActionResult ResetPassword(string email);

    }
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        [HttpPost,Route("login")]
        public ActionResult<UserResponse> Login(UserLoginRequest request)
        {
            Ok(new UserResponse());
            throw new NotImplementedException();
        }

        [HttpPost, Route("register")]
        public ActionResult Register(UserBasic request)
        {
            Ok();
            // create asp user , employee , membership , account 
            throw new NotImplementedException();
        }

        [HttpPost, Route("reset")]
        public ActionResult ResetPassword([FromBody]string email)
        {
            Ok();
            throw new NotImplementedException();
        }
    }
}