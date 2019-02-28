using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PayrollDetailCategory
    {
        public PayrollDetailCategory()
        {
            PayrollDetail = new HashSet<PayrollDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Priority { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PayrollDetail> PayrollDetail { get; set; }
    }
}
