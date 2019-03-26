using AutoMapper;
using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class TimeFrameBasic : BaseViewModel<TimeFrame>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("start_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan StartTime { get; set; }
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan EndTime { get; set; }
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan Duration { get; set; }
        [JsonProperty("brand_id",NullValueHandling = NullValueHandling.Ignore)]
        public int BrandId { get; set; }
        [JsonProperty("employee_group_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? EmployeeGroupId { get; set; }
        [JsonProperty("break_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan BreakTime { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        [JsonProperty("is_orver_time", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOverTime { get; set; }
        [JsonProperty("in_mode", NullValueHandling = NullValueHandling.Ignore)]
        public int? InMode { get; set; }
        [JsonProperty("out_mode", NullValueHandling = NullValueHandling.Ignore)]
        public int? OutMode { get; set; }
        [JsonProperty("break_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? BreakCount { get; set; }
        [JsonProperty("check_in_expand_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? CheckInExpandTime { get; set; }
        [JsonProperty("check_out_expand_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? CheckOutExpandTime { get; set; }
        [JsonProperty("store_filter", NullValueHandling = NullValueHandling.Ignore)]
        public int? StoreFilter { get; set; }
        [JsonProperty("come_late_expand_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? ComeLateExpandTime { get; set; }
        [JsonProperty("leave_early_expand_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan? LeaveEarlyExpandTime { get; set; }
    }

    public class TimeFrameRequestCreate : BaseViewModel<TimeFrame>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("start_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan StartTime { get; set; }
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan EndTime { get; set; }
        [JsonIgnore]
        public TimeSpan Duration { get; set; }
        [JsonProperty("brand_id", NullValueHandling = NullValueHandling.Ignore)]
        public int BrandId { get; set; }
        [JsonIgnore]
        public int? EmployeeGroupId { get; set; }
        [JsonProperty("break_time", NullValueHandling = NullValueHandling.Ignore)]
        public TimeSpan BreakTime { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        public TimeFrameRequestCreate() { }
        public TimeFrameRequestCreate(TimeFrame entity, IMapper mapper) : base(entity, mapper) { }
    }
}
