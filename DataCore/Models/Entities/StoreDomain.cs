using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class StoreDomain
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Protocol { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string Directory { get; set; }
        public bool Active { get; set; }

        public virtual Store Store { get; set; }
    }
}
