using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class SalaryLevel
    {
        public SalaryLevel()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string SalaryLevelName { get; set; }
        public double? SalaryValue { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
