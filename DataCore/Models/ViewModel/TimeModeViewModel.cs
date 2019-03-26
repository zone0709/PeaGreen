using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class TimeModeBasic : BaseViewModel<TimeModeRule>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("time_mode_name")]
        public string TimeModeName { get; set; }
        [JsonProperty("workingshift_type")]
        public int? WorkingShiftType { get; set; }
        [JsonProperty("time_Start")]
        public TimeSpan? TimeStart { get; set; }
        [JsonProperty("time_end")]
        public TimeSpan? TimeEnd { get; set; }
        [JsonProperty("duration_min")]
        public TimeSpan? DurationMin { get; set; }
        [JsonProperty("duration_max")]
        public TimeSpan? DurationMax { get; set; }
        [JsonProperty("day_type_id")]
        public int? DayTypeId { get; set; }
        [JsonProperty("priority")]
        public int? Priority { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
        [JsonIgnore]
        public DateTime? DateCreate { get; set; }
    }
    public class TimeModeTimeRequest
    {
        public int Id { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
    }
}
