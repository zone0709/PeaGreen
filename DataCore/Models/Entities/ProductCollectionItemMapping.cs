﻿using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class ProductCollectionItemMapping
    {
        public int Id { get; set; }
        public int ProductCollectionId { get; set; }
        public int ProductId { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductCollection ProductCollection { get; set; }
    }
}
