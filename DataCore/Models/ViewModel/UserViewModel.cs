using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class UserBasic /*: BaseViewModel<AspNetUsers>*/
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int BrandId { get; set; }
    }
    public class UserLoginRequest 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserResponse
    {
        public EmployeeBasic Employee { get; set; }

    }
}
