﻿using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class OrderPromotionMapping
    {
        public OrderPromotionMapping()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PromotionId { get; set; }
        public int? PromotionDetailId { get; set; }
        public decimal DiscountAmount { get; set; }
        public double? DiscountRate { get; set; }
        public bool Active { get; set; }
        public int MappingIndex { get; set; }
        public int? TmpMappingId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
