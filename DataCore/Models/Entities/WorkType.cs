using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class WorkType
    {
        public int Id { get; set; }
        public string WorkTypeName { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public double WorkTypeRate { get; set; }
        public bool IsUnNormal { get; set; }
        public bool IsActive { get; set; }
    }
}
