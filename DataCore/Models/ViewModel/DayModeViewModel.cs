using AutoMapper;
using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{

    public class DayModeBasic : BaseViewModel<DayMode>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("day_of_week")]
        public List<DayofWeeksActive> DayofWeek { get; set; }
        [JsonProperty("priority")]
        public int? Priority { get; set; }
        [JsonIgnore]
        public int BrandId { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        public DayModeBasic() { }
        public DayModeBasic(DayMode entity, IMapper mapper) : base(entity, mapper) { }
    }

    public class DayofWeeks
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class DayofWeeksActive : DayofWeeks
    {
        [JsonProperty("active")]
        public bool Active { get; set; }
    }

    public class DayModeCreateRequest : BaseViewModel<DayMode>
    {

        [JsonProperty("name")]
        public string Name { get; set; }
        public int BrandId { get; set; }
        public bool Active { get; set; }
        [JsonProperty("days_of_the_week")]
        public List<int> DaysOfTheWeek { get; set; }

    }

    public class DayModeBasicRequest
    {
        public int Id { get; set; }
    }
    public class DayModeDofWRequest : DayModeBasicRequest
    {
        public int DayofWeek { get; set; }
    }
    public class DayModeDateRequest : DayModeBasicRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
    public class DayModeDeActiveRequest : DayModeBasicRequest
    {
    }
}
