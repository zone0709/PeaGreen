using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class CheckFingerBasic : BaseViewModel<CheckFinger>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int? FingerScanMachineId { get; set; }
        [JsonIgnore]
        public DateTime DateTime { get; set; }
        [JsonIgnore]
        public int? Mode { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        [JsonProperty("store_id")]
        public int? StoreId { get; set; }
        [JsonIgnore]
        public string MachineNumber { get; set; }
        [JsonProperty("code")]
        public string EmpEnrollNumber { get; set; }
        [JsonIgnore]
        public bool? IsUpdated { get; set; }
        [JsonIgnore]
        public string LogCode { get; set; }
    }
}
