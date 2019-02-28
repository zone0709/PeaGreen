using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PayrollDetail
    {
        public PayrollDetail()
        {
            PaySlipItem = new HashSet<PaySlipItem>();
            PaySlipTemplateMapping = new HashSet<PaySlipTemplateMapping>();
            PayrollFormula = new HashSet<PayrollFormula>();
        }

        public int Id { get; set; }
        public int? PayrollDetailCategoryId { get; set; }
        public int? SalaryRuleGroupId { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }
        public string Description { get; set; }
        public int? DefaultFormulaId { get; set; }
        public string Frequency { get; set; }
        public string Variability { get; set; }
        public string Destination { get; set; }
        public bool? IsActive { get; set; }

        public virtual PayrollDetailCategory PayrollDetailCategory { get; set; }
        public virtual SalaryRuleGroup SalaryRuleGroup { get; set; }
        public virtual ICollection<PaySlipItem> PaySlipItem { get; set; }
        public virtual ICollection<PaySlipTemplateMapping> PaySlipTemplateMapping { get; set; }
        public virtual ICollection<PayrollFormula> PayrollFormula { get; set; }
    }
}
