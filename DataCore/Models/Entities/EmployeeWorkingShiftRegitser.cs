using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class EmployeeWorkingShiftRegitser
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? WorkingShiftId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? TimeCreated { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual WorkingShift WorkingShift { get; set; }
    }
}
