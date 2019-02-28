using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class WorkingShift
    {
        public WorkingShift()
        {
            EmployeeWorkingShiftRegitser = new HashSet<EmployeeWorkingShiftRegitser>();
        }

        public int Id { get; set; }
        public string WorkingShiftName { get; set; }
        public int? WorkingShiftType { get; set; }
        public TimeSpan? ShiftMin { get; set; }
        public TimeSpan? ShiftMax { get; set; }
        public TimeSpan? ExpandTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EmployeeWorkingShiftRegitser> EmployeeWorkingShiftRegitser { get; set; }
    }
}
