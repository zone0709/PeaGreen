using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PayrollDetail
    {
        public PayrollDetail()
        {
            PaySlipItem = new HashSet<PaySlipItem>();
            PayrollFormula = new HashSet<PayrollFormula>();
            TemplateDetailMapping = new HashSet<TemplateDetailMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }
        public bool Active { get; set; }
        public int? BrandId { get; set; }
        public int? SalaryRuleGroupId { get; set; }
        public string Description { get; set; }
        public int? DefaultFormulaId { get; set; }
        public string Frequency { get; set; }
        public string Variability { get; set; }
        public string Destination { get; set; }
        public int? PayrollDetailCategoryId { get; set; }

        public virtual PayrollDetailCategory PayrollDetailCategory { get; set; }
        public virtual SalaryRuleGroup SalaryRuleGroup { get; set; }
        public virtual ICollection<PaySlipItem> PaySlipItem { get; set; }
        public virtual ICollection<PayrollFormula> PayrollFormula { get; set; }
        public virtual ICollection<TemplateDetailMapping> TemplateDetailMapping { get; set; }
    }
}
