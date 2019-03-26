using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataCore.Models.Indentities
{
    public class AuthenticationFailureResult : IHttpActionResult
    {
        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request, HttpStatusCode statusCode, int resultCode)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
            StatusCode = statusCode;
            ResultCode = resultCode;
        }

        public string ReasonPhrase { get; private set; }

        public HttpRequestMessage Request { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public int ResultCode { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            return new HttpResponseMessage()
            {
                StatusCode = StatusCode,
                Content = new JsonContent(new BaseResponse<string>()
                {
                    ResultCode = ResultCode,
                    Success = false,
                    Message = ReasonPhrase,
                })
            };
            //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            //response.RequestMessage = Request;
            //response.ReasonPhrase = ReasonPhrase;
            //return response;
        }
    }
}
