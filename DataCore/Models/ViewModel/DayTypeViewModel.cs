using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class DayTypeBasic : BaseViewModel<DayType>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string DayTypeName { get; set; }
        [JsonProperty("days_of_the_week")]
        public string DaysOfTheWeek { get; set; }
        [JsonProperty("from_date")]
        public DateTime? FromDate { get; set; }
        [JsonProperty("to_date")]
        public DateTime? ToDate { get; set; }
        [JsonProperty("priority")]
        public int? Priority { get; set; }
        [JsonIgnore]
        public int BrandId { get; set; }
        //public bool IsActive { get; set; }
        [JsonProperty("date_create")]
        public DateTime? DateCreate { get; set; }
    }
    public class DayTypeBasicRequest
    {
        public int Id { get; set; }
    }
    public class DayTypeDofWRequest : DayTypeBasicRequest
    {
        public int DayofWeek { get; set; }
    }
    public class DayTypeDateRequest : DayTypeBasicRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
    public class DayTypeDeActiveRequest : DayTypeBasicRequest
    {
    }
}
