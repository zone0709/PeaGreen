using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class SalaryRule
    {
        public SalaryRule()
        {
            SalaryRuleGroupMapping = new HashSet<SalaryRuleGroupMapping>();
        }

        public int Id { get; set; }
        public int? TimeModeId { get; set; }
        public string Name { get; set; }
        public double? DurationMin { get; set; }
        public double? DurationMax { get; set; }
        public double? FixValue { get; set; }
        public double? RateValue { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<SalaryRuleGroupMapping> SalaryRuleGroupMapping { get; set; }
    }
}
