using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class WorkingShiftAutoTmp
    {
        public WorkingShiftAutoTmp()
        {
            EmployeeWorkingShiftAutoMapping = new HashSet<EmployeeWorkingShiftAutoMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? WorkingShiftType { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public TimeSpan? TimeExpand { get; set; }
        public int? EmptySlot { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<EmployeeWorkingShiftAutoMapping> EmployeeWorkingShiftAutoMapping { get; set; }
    }
}
