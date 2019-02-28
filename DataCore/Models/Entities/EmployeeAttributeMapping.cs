using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class EmployeeAttributeMapping
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeAttributeId { get; set; }
        public string Quality { get; set; }
        public int? Quantity { get; set; }
        public bool? IsActive { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual EmployeeAttribute EmployeeAttribute { get; set; }
    }
}
