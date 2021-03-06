﻿using DataCore.Models.Entities;
using DataCore.Models.Utilities;
using Doitsu.Service.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Http.ModelBinding;

namespace DataCore.Models.ViewModel
{
    public class AttendanceBasic : BaseViewModel<Attendance>
    {
        public int EmployeeId { get; set; }
        public DateTime? CheckMin { get; set; }
        public DateTime? CheckMax { get; set; }
        public TimeSpan? TotalWorkTime { get; set; }
        public int? Status { get; set; }
        public DateTime ShiftMin { get; set; }
        public DateTime ShiftMax { get; set; }
        public TimeSpan ExpandTime { get; set; }
        public string UpdatePerson { get; set; }
        public int? ProcessingStatus { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public int StoreId { get; set; }
        public TimeSpan? BreakTime { get; set; }
        public int TimeFramId { get; set; }
        public DateTime? RequestedCheckOut { get; set; }
        public DateTime? RequestedCheckIn { get; set; }
        public int? IsRequested { get; set; }
        public string ApprovePerson { get; set; }
        public string NoteRequest { get; set; }
        public DateTime? LastCheckBeforeShift { get; set; }
        public DateTime? FirstCheckAfterShift { get; set; }
        public bool? IsOverTime { get; set; }
        public int? InMode { get; set; }
        public int? OutMode { get; set; }
        public int? BreakCount { get; set; }
        public TimeSpan? CheckInExpandTime { get; set; }
        public TimeSpan? CheckOutExpandTime { get; set; }
        public TimeSpan? ComeLateExpandTime { get; set; }
        public TimeSpan? LeaveEarlyExpandTime { get; set; }
        public int? BrandId { get; set; }

    }
    public class AttentdenceRequest : BaseViewModel<Attendance>
    {
        [JsonProperty("employee_id")]
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public int? Status { get; set; }
        [JsonProperty("list_date")]
        public List<DateTime> Dates { get; set; }
        [JsonProperty("list_shift_min")]
        public List<TimeSpan> ShiftMinTime { get; set; }
        [JsonProperty("list_shift_max")]
        public List<TimeSpan> ShiftMaxTime { get; set; }
        [JsonIgnore]
        public string UpdatePerson { get; set; }
        [JsonIgnore]
        public int? ProcessingStatus { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        [JsonProperty("store_id")]
        public int StoreId { get; set; }
        [JsonProperty("list_time_frame_id")]
        public List<int> TimeFramId { get; set; }
        [JsonProperty("brand_id")]
        public int? BrandId { get; set; }
    }
    public class AttentdenceAcceptRequest : BaseViewModel<Attendance>
    {
        [JsonProperty("list_shift_id")]
        public List<int> ListShiftRegisterId { get; set; }
        [JsonProperty("store_id")]
        public int StoreId { get; set; }
    }
    public class AttendanceResponse : BaseViewModel<Attendance>
    {
        [JsonProperty("check_min")]
        public DateTime? CheckMin { get; set; }
        [JsonProperty("check_max")]
        public DateTime? CheckMax { get; set; }
        [JsonProperty("total_hour")]
        public TimeSpan? TotalWorkTime { get; set; }
        [JsonProperty("status")]
        public int? Status { get; set; }
        [JsonProperty("shift_min")]
        public DateTime ShiftMin { get; set; }
        [JsonProperty("shift_max")]
        public DateTime ShiftMax { get; set; }
    }
    public class AttendanceStatusResponse 
    {
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
    //[ModelBinder(typeof(SkyModelBinder))]
    public class AttendanceQueryRequest
    {
        [FromQuery(Name ="to_date")]
        public string ToDate { get; set; }
        [FromQuery(Name = "from_date")]
        public string FromDate { get; set; }
        [FromQuery(Name = "emp_id")]
        public int? EmpId { get; set; } 
    }

}
