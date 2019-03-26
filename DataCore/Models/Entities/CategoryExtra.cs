using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class CategoryExtra
    {
        public int CategoryExtraId { get; set; }
        public int PrimaryCategoryId { get; set; }
        public int ExtraCategoryId { get; set; }
        public bool IsEnable { get; set; }
    }
}
