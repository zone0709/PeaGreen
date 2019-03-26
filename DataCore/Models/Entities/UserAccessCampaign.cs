using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class UserAccessCampaign
    {
        public int Id { get; set; }
        public int UserAccessId { get; set; }
        public int CampaignId { get; set; }
    }
}
