using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class ConstantManager
    {
        public const string SUCCESS = " Success ";
        public const string FAIL = " Fail ";
        public const string NOTIMPLEMENT = " Not Implement ! ";
        public const string UNAUTHORIZED = "User or Password not match !";
        public const string MES_REQUEST_DENY = "Không có quyền thực hiện yêu cầu này";
        public const string MES_NOT_ACTIVE = "Tài khoản không hiệu lực";
        public const string MES_ROLE_WRONG = "Attribute block is wrong";
        public static string Fail(string e)
        {
            return e + FAIL;
        }
        public static string Success(string e)
        {
            return e + SUCCESS;
        }
        public static string CreateError(string e)
        {
            return e + " Create" + FAIL;
        }
        public static string CreateSuccess(string e)
        {
            return e + " Create" + SUCCESS;
        }
        public static string NotFound(string e)
        {
            return e + " Not Found !" ;
        }

    }
   
}
