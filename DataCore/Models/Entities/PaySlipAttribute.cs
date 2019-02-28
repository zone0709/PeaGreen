using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PaySlipAttribute
    {
        public PaySlipAttribute()
        {
            PaySlipAttributeMapping = new HashSet<PaySlipAttributeMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PaySlipAttributeMapping> PaySlipAttributeMapping { get; set; }
    }
}
