using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class EmployeeGroupMapping
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeGroupId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual EmployeeGroup EmployeeGroup { get; set; }
    }
}
