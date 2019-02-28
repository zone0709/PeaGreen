using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class SalaryRuleGroupMapping
    {
        public int Id { get; set; }
        public int? SalaryRuleGroupId { get; set; }
        public int? SalaryRuleId { get; set; }
        public bool? IsActive { get; set; }

        public virtual SalaryRule SalaryRule { get; set; }
        public virtual SalaryRuleGroup SalaryRuleGroup { get; set; }
    }
}
