using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class EmployeeJobMapping
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? EmployeeRoleId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual EmployeeJob EmployeeRole { get; set; }
    }
}
