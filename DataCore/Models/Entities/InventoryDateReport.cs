﻿using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class InventoryDateReport
    {
        public InventoryDateReport()
        {
            InventoryDateReportItem = new HashSet<InventoryDateReportItem>();
        }

        public int ReportId { get; set; }
        public int StoreId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Creator { get; set; }
        public int Status { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<InventoryDateReportItem> InventoryDateReportItem { get; set; }
    }
}
