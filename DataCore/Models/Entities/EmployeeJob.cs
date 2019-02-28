using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class EmployeeJob
    {
        public EmployeeJob()
        {
            EmployeeJobMapping = new HashSet<EmployeeJobMapping>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<EmployeeJobMapping> EmployeeJobMapping { get; set; }
    }
}
