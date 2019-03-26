using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PayslipAttribute
    {
        public PayslipAttribute()
        {
            PayslipAttributeMapping = new HashSet<PayslipAttributeMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int BrandId { get; set; }
        public string Code { get; set; }

        public virtual ICollection<PayslipAttributeMapping> PayslipAttributeMapping { get; set; }
    }
}
