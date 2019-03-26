﻿using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class ImageCollection
    {
        public ImageCollection()
        {
            ImageCollectionItem = new HashSet<ImageCollectionItem>();
        }

        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<ImageCollectionItem> ImageCollectionItem { get; set; }
    }
}
