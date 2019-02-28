using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class TimeSummary
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int TimeModeId { get; set; }
        public int? PayrollPeriodId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? TotalHours { get; set; }
        public int? Status { get; set; }
        public string UpdatedPerson { get; set; }
        public bool IsActive { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual TimeMode TimeMode { get; set; }
    }
}
