using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class AttendanceTmp
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? Time { get; set; }
        public string ImageSrc { get; set; }
        public double? Confidence { get; set; }
        public bool IsActive { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
