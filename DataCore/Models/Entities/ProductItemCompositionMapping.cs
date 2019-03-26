using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class ProductItemCompositionMapping
    {
        public int ProducId { get; set; }
        public int ItemId { get; set; }
        public double Quantity { get; set; }

        public virtual ProductItem Item { get; set; }
        public virtual Product Produc { get; set; }
    }
}
