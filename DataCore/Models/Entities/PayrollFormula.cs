using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PayrollFormula
    {
        public int Id { get; set; }
        public int? PayrollDetailId { get; set; }
        public string Condition { get; set; }
        public string Expression { get; set; }
        public bool IsActive { get; set; }

        public virtual PayrollDetail PayrollDetail { get; set; }
    }
}
