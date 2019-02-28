using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class TimeMode
    {
        public TimeMode()
        {
            TimeSummary = new HashSet<TimeSummary>();
        }

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

        public virtual DayType DayType { get; set; }
        public virtual ICollection<TimeSummary> TimeSummary { get; set; }
    }
}
