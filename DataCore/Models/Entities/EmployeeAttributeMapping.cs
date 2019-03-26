﻿using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class EmployeeAttributeMapping
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? AttributeId { get; set; }
        public int? Value { get; set; }
        public bool Active { get; set; }
        public string Quality { get; set; }

        public virtual EmployeeAttribute Attribute { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
