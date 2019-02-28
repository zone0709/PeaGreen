using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class SalaryRuleGroup
    {
        public SalaryRuleGroup()
        {
            PayrollDetail = new HashSet<PayrollDetail>();
            SalaryRuleGroupMapping = new HashSet<SalaryRuleGroupMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PayrollDetail> PayrollDetail { get; set; }
        public virtual ICollection<SalaryRuleGroupMapping> SalaryRuleGroupMapping { get; set; }
    }
}
