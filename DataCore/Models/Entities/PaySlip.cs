using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PaySlip
    {
        public PaySlip()
        {
            PaySlipAttributeMapping = new HashSet<PaySlipAttributeMapping>();
            PaySlipItem = new HashSet<PaySlipItem>();
        }

        public int Id { get; set; }
        public int? PayrollPeriodId { get; set; }
        public int EmployeeId { get; set; }
        public double? NetPay { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual PayrollPeriod PayrollPeriod { get; set; }
        public virtual ICollection<PaySlipAttributeMapping> PaySlipAttributeMapping { get; set; }
        public virtual ICollection<PaySlipItem> PaySlipItem { get; set; }
    }
}
