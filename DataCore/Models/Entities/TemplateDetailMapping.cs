using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class TemplateDetailMapping
    {
        public int Id { get; set; }
        public int PaySlipTemplateId { get; set; }
        public int? PayrollDetailId { get; set; }
        public bool Active { get; set; }

        public virtual PaySlipTemplate PaySlipTemplate { get; set; }
        public virtual PayrollDetail PayrollDetail { get; set; }
    }
}
