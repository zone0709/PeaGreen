﻿using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PayslipAttributeMapping
    {
        public int Id { get; set; }
        public int? PayslipId { get; set; }
        public int? AttributeId { get; set; }
        public int? Value { get; set; }
        public bool Active { get; set; }
        public string Quality { get; set; }

        public virtual PayslipAttribute Attribute { get; set; }
        public virtual PaySlip Payslip { get; set; }
    }
}
