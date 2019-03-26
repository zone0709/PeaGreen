using AutoMapper;
using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class ShiftRegisterBasic : BaseViewModel<ShiftRegister>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("employee_id")]
        public int EmployeeId { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "start_time is required!")]
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "end_time is required!")]
        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "time_frame_id is required!")]
        [JsonProperty("time_frame_id")]
        public int? TimeframeId { get; set; }
        [JsonIgnore]
        public int? Status { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        public ShiftRegisterBasic() { }
        public ShiftRegisterBasic(ShiftRegister entity, IMapper mapper) : base(entity, mapper) { }
    }

    public class ShiftRegisterResponse : BaseViewModel<ShiftRegister>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string EmpName { get; set; }
        [JsonProperty("start_time")]
        public TimeSpan StartTimeVM { get; set; }
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("end_time")]
        public TimeSpan EndTimeVM { get; set; }
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }
        [JsonProperty("time_frame_id")]
        public int? TimeframeId { get; set; }
        [JsonProperty("status")]
        public string StatusName { get; set; }
        public ShiftRegisterResponse() { }
        public ShiftRegisterResponse(ShiftRegister entity, IMapper mapper) : base(entity, mapper) { }
    }
}
