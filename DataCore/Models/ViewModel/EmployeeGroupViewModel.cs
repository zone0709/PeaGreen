using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class EmployeeGroupBasic : BaseViewModel<EmployeeGroup>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string NameGroup { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        [JsonIgnore]
        public int BrandId { get; set; }
        [JsonIgnore]
        public DateTime? CreateDate { get; set; }
    }

}
