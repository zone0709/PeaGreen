using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class CouponProvider
    {
        public CouponProvider()
        {
            CouponCampaign = new HashSet<CouponCampaign>();
        }

        public int Id { get; set; }
        public string ProviderName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CouponCampaign> CouponCampaign { get; set; }
    }
}
