using DataCore.Models.Utilities;
using DataCore.Models.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models.Service
{
    public class UserService : IUserService
    {
        readonly IEmployeeService employeeService;
        public UserService(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public async Task Register(string brandToken, UserBasic model)
        {
            using (var client = new HttpClient())
            {
                //ServicePointManager.ServerCertificateValidationCallback +=
                //(sender, cert, chain, sslPolicyErrors) => true;
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                client.BaseAddress = new Uri("http://authorizecore.unicode.edu.vn");
                //client.DefaultRequestHeaders.Accept.Add(
                //new MediaTypeWithQualityHeaderValue("application/json"));
                var oBject = new
                {
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.Password,
                    brandToken = brandToken
                };

                var response = await client.PostAsJsonAsync("/api/authorize/register", oBject);
                if (response.IsSuccessStatusCode)
                {
                    //var responseObj = await response.Content.ReadAsAsync<JObject>();
                    //var data =  responseObj.SelectToken("data");
                    //var email = data.SelectToken("email").ToString();
                    employeeService.Add(model);
                }

            }




        }
        public async Task<UserResponse> Login(string brandToken, UserLoginRequest model)
        {
            try
            {
                var result = new UserResponse();
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://authorizecore.unicode.edu.vn");
                    var oBject = new
                    {
                        Email = model.Email,
                        Password = model.Password,
                        brandToken = brandToken
                    };

                    var response = await client.PostAsJsonAsync("/api/authorize/login", oBject);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseObj = await response.Content.ReadAsAsync<JObject>();
                        var token = responseObj.SelectToken("token").ToString();
                        var role = responseObj.SelectToken("roles").ToArray();
                        var emp = employeeService.Get(model.Email).FirstOrDefault();
                        result.Token = token;
                        result.Employee = emp;
                        result.Role = role;
                        //var tokenJWT = Utils.DecodeJwtToken(token);
                        //tokenJWT.Claims.Where(p => p.Type )
                        //var email = data.SelectToken("email").ToString();
                        //employeeService.Add(model);
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            throw ApiException.Get(false, ConstantManager.UNAUTHORIZED, ResultEnum.Unauthorization, HttpStatusCode.Unauthorized);
                        }
                        else
                        {
                            throw ApiException.Get(false, ConstantManager.FAIL, ResultEnum.InternalError, HttpStatusCode.InternalServerError);
                        }
                    }


                }
                return result;
            }
            catch (Exception ex)
            {
                if (ex is ApiException)
                {
                    throw ex;
                }
                else
                {
                  throw  ApiException.Get(false, ConstantManager.FAIL, ResultEnum.InternalError, HttpStatusCode.InternalServerError);
                }
            }




        }
    }
}
