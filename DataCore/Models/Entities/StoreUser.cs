using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class StoreUser
    {
        public string Username { get; set; }
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
