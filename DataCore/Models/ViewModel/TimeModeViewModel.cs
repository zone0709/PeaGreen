using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class TimeModeBasic /*: BaseViewModel<TimeMode>*/
    {
        public int Id { get; set; }
        public string TimeModeName { get; set; }
        public int? WorkingShiftType { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public TimeSpan? DurationMin { get; set; }
        public TimeSpan? DurationMax { get; set; }
        public int? DayTypeId { get; set; }
        public int? Priority { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateCreate { get; set; }
    }
    public class TimeModeTimeRequest
    {
        public int Id { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
    }
}
