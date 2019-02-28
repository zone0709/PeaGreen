using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class EmployeeJobBasic : BaseViewModel<EmployeeJob>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string RoleName { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; }

    }
}
