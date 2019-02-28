using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class DayType
    {
        public DayType()
        {
            TimeMode = new HashSet<TimeMode>();
        }

        public int Id { get; set; }
        public string DayTypeName { get; set; }
        public string DaysOfTheWeek { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Priority { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateCreate { get; set; }

        public virtual ICollection<TimeMode> TimeMode { get; set; }
    }
}
