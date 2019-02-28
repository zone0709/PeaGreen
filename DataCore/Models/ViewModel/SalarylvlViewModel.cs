using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class SalarylvlBasic : BaseViewModel<SalaryLevel>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string SalaryLevelName { get; set; }
        [JsonProperty("value")]
        public double? SalaryValue { get; set; }
        [JsonProperty("brand_id")]
        [JsonIgnore]
        public int BrandId { get; set; }
        //public bool IsActive { get; set; }
    }

    public class SalarylvlBasicRequest
    {
        public int SalarylvlId { get; set; }
    }
    public class ValueRequest : SalarylvlBasicRequest
    {
        public int Value { get; set; }
    }

    public class DeActiveRequest : SalarylvlBasicRequest
    {
        public int SalarylvlId { get; set; }
    }
    public class SalarylvlNameRequest : SalarylvlBasicRequest
    {
        public string Name { get; set; }
    }
}
