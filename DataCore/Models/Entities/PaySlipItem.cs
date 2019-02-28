using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PaySlipItem
    {
        public PaySlipItem()
        {
            PaySlipItemAttributeMapping = new HashSet<PaySlipItemAttributeMapping>();
        }

        public int Id { get; set; }
        public int PaySlipId { get; set; }
        public int PayrollDeatilId { get; set; }
        public double? Value { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual PaySlip PaySlip { get; set; }
        public virtual PayrollDetail PayrollDeatil { get; set; }
        public virtual ICollection<PaySlipItemAttributeMapping> PaySlipItemAttributeMapping { get; set; }
    }
}
