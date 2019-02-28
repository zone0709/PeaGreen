using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class PayrollPeriodViewModel : BaseViewModel<PayrollPeriod>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("payslip_template_id")]
        public int? PaySlipTemplateId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("from_date")]
        public DateTime? FromDate { get; set; }
        [JsonProperty("to_date")]
        public DateTime? ToDate { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; }
    }
}
