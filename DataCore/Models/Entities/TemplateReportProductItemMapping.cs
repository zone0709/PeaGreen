using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class TemplateReportProductItemMapping
    {
        public int Id { get; set; }
        public int InventoryTemplateReportId { get; set; }
        public int ProductItemId { get; set; }
        public int MappingIndex { get; set; }

        public virtual InventoryTemplateReport InventoryTemplateReport { get; set; }
        public virtual ProductItem ProductItem { get; set; }
    }
}
