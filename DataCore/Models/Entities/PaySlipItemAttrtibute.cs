using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PaySlipItemAttrtibute
    {
        public PaySlipItemAttrtibute()
        {
            PaySlipItemAttributeMapping = new HashSet<PaySlipItemAttributeMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PaySlipItemAttributeMapping> PaySlipItemAttributeMapping { get; set; }
    }
}
