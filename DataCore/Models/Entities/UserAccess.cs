using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class UserAccess
    {
        public int Id { get; set; }
        public int? UserAccessCampaignId { get; set; }
    }
}
