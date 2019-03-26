using AutoMapper;
using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class PayrollDetailBasic  : BaseViewModel<PayrollDetail>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("payroll_detail_category_id")]
        public int? PayrollDetailCategoryId { get; set; }
        [JsonProperty("salary_rule_group_id")]
        public int? SalaryRuleGroupId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public double? Value { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("default_formula_id")]
        public int? DefaultFormulaId { get; set; }
        [JsonProperty("frequency")]
        public string Frequency { get; set; }
        [JsonProperty("variability")]
        public string Variability { get; set; }
        [JsonProperty("destination")]
        public string Destination { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; }
    }
    public class PayrollDetailCheckResponse : BaseViewModel<PayrollDetail>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("check")]
        public bool Check { get; set; }
        public PayrollDetailCheckResponse() { }
        public PayrollDetailCheckResponse(PayrollDetail entity, IMapper mapper) : base(entity, mapper) { }
    }

    public class PayrollDetailResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("payroll_detail_category_id")]
        public int? PayrollDetailCategoryId { get; set; }
        [JsonProperty("salary_rule_group_id")]
        public int? SalaryRuleGroupId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public double? Value { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("default_formula_id")]
        public int? DefaultFormulaId { get; set; }
        [JsonProperty("frequency")]
        public string Frequency { get; set; }
        [JsonProperty("variability")]
        public string Variability { get; set; }
        [JsonProperty("destination")]
        public string Destination { get; set; }
    }
}
