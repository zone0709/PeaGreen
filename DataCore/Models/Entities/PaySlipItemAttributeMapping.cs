using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PaySlipItemAttributeMapping
    {
        public int Id { get; set; }
        public int? PaySlipItemId { get; set; }
        public int? PaySlipItemAttributeId { get; set; }
        public string Quality { get; set; }
        public int? Quantity { get; set; }
        public bool? IsActive { get; set; }

        public virtual PaySlipItem PaySlipItem { get; set; }
        public virtual PaySlipItemAttrtibute PaySlipItemAttribute { get; set; }
    }
}
