using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class RoomCategoryPriceGroupMapping
    {
        public int CategoryId { get; set; }
        public int PriceGroupId { get; set; }
        public bool IsDefault { get; set; }

        public virtual RoomCategory Category { get; set; }
        public virtual PriceGroup PriceGroup { get; set; }
    }
}
