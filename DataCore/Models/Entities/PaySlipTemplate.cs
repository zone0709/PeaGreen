using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PaySlipTemplate
    {
        public PaySlipTemplate()
        {
            PaySlipTemplateMapping = new HashSet<PaySlipTemplateMapping>();
            PayrollPeriod = new HashSet<PayrollPeriod>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PaySlipTemplateMapping> PaySlipTemplateMapping { get; set; }
        public virtual ICollection<PayrollPeriod> PayrollPeriod { get; set; }
    }
}
