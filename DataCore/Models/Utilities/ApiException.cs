using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataCore.Models.Utilities
{
    public class ApiException : SystemException
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public ResultEnum ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }

        public static ApiException Get(bool success, string mess, ResultEnum errorStatus, HttpStatusCode statusCode)
        {
            return new ApiException()
            {
                Success = success,
                ErrorMessage = mess,
                ErrorStatus = errorStatus,
                StatusCode = (int)statusCode
            };
        }
    }
}
