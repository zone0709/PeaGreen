using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class EmployeeWorkingShiftAutoMapping
    {
        public int Id { get; set; }
        public int? WorkingShiftAutoTmpId { get; set; }
        public int EmployeeId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual WorkingShiftAutoTmp WorkingShiftAutoTmp { get; set; }
    }
}
