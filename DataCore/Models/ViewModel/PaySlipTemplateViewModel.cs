using AutoMapper;
using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class PaySlipTemplateBasic : BaseViewModel<PaySlipTemplate>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public bool? Active { get; set; }
        [JsonIgnore]
        public int BrandId { get; set; }
        [JsonProperty("list_payroll_detail")]
        public List<int> ListIdPayrollDetail { get; set; }
    }
    public class PaySlipTemplateResponse : BaseViewModel<PaySlipTemplate>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class PaySlipRequestDelete : BaseViewModel<PaySlipTemplate>
    {
        [JsonProperty("list_id")]
        public List<int> ListId { get; set; }
    }
    public class PaySlipTemplateDetailResponse : BaseViewModel<PaySlipTemplate>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("list_payroll_detail")]
        public List<PayrollDetailCheckResponse> ListPayrollDetail { get; set; }
        public PaySlipTemplateDetailResponse() { }
        public PaySlipTemplateDetailResponse(PaySlipTemplate entity, IMapper mapper) : base(entity, mapper) { }

    }
}
