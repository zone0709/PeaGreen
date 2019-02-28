using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? WorkingShiftType { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? CheckMin { get; set; }
        public TimeSpan? CheckMax { get; set; }
        public TimeSpan? ShiftMin { get; set; }
        public TimeSpan? ShiftMax { get; set; }
        public TimeSpan? ExpandTime { get; set; }
        public int? Status { get; set; }
        public string UpdatePerson { get; set; }
        public string ImageIn { get; set; }
        public string ImageOut { get; set; }
        public double? ConfidenceIn { get; set; }
        public double? ConfidenceOut { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
