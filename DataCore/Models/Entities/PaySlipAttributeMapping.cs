using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PaySlipAttributeMapping
    {
        public int Id { get; set; }
        public int? PaySlipId { get; set; }
        public int? PaySlipAttributeId { get; set; }
        public string Quality { get; set; }
        public double? Quantity { get; set; }
        public bool? IsActive { get; set; }

        public virtual PaySlip PaySlip { get; set; }
        public virtual PaySlipAttribute PaySlipAttribute { get; set; }
    }
}
