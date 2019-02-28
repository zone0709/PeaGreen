using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class EmployeeGroup
    {
        public EmployeeGroup()
        {
            EmployeeGroupMapping = new HashSet<EmployeeGroupMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<EmployeeGroupMapping> EmployeeGroupMapping { get; set; }
    }
}
