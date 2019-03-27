using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class UserBasic /*: BaseViewModel<AspNetUsers>*/
    {
        [JsonProperty("email")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "email is required !")]
        public string Email { get; set; }
        [JsonProperty("password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "password is required !")]
        public string Password { get; set; }
        [JsonProperty("name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "name is required !")]
        public string Name { get; set; }
        [JsonProperty("address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "address is required !")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "store_id is required !")]
        [JsonProperty("store_id")]
        public int MainStoreId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "phone is required !")]
        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        //public int BrandId { get; set; }
    }
    public class UserLoginRequest 
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class UserResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("employee")]
        public EmployeeBasic Employee { get; set; }
        [JsonProperty("role")]
        public Array Role { get; set; }
        [JsonProperty("membership")]
        public ResoLoyalty.Client.Models.Membership Membership { get; set; }

    }
    public class UserConfiguration
    {
        public string BrandToken { get; set; }
        public string RegisAdminToken { get; set; }
        public string AUDIENCE { get; set; }
        public string ISSUER { get; set; }
        public string SECRETKEY { get; set; }
        public string Loyalty { get; set; }
    }
}
