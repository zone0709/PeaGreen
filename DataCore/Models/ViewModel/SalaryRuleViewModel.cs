using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class SalaryRuleBasic : BaseViewModel<SalaryRule>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("timemode_id")]
        public int? TimeModeId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("duration_min")]
        public double? DurationMin { get; set; }
        [JsonProperty("duration_max")]
        public double? DurationMax { get; set; }
        [JsonProperty("fix_value")]
        public double? FixValue { get; set; }
        [JsonProperty("rate_value")]
        public double? RateValue { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; }
    }
    public class SalaryRuleResponse : BaseViewModel<SalaryRule>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("timemode_id")]
        public int? TimeModeRuleId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("duration_min")]
        public double? MinTimeDuration { get; set; }
        [JsonProperty("duration_max")]
        public double? MaxTimeDuration { get; set; }
        [JsonProperty("value")]
        public double? Value { get; set; }
        [JsonProperty("rate_value")]
        public double? Rate { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; }
    }
}
