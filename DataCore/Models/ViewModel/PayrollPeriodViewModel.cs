using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class PayrollPeriodBasic : BaseViewModel<PayrollPeriod>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("payslip_template_id")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "payslip_template_id is required!")]
        public int? PaySlipTemplateId { get; set; }
        [JsonProperty("name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "name is required!")]
        public string Name { get; set; }
        [JsonProperty("from_date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "from_date is required!")]
        public DateTime? FromDate { get; set; }
        [JsonProperty("to_date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "to_date is required!")]
        public DateTime? ToDate { get; set; }
        [JsonIgnore]
        public bool? IsActive { get; set; }
    }
    public class PayrollPeriodApply : BaseViewModel<PayrollPeriod>
    {
        [JsonProperty("period_apply_id")]
        public int Id { get; set; }
        [JsonProperty("list_emp")]
        public List<int> ListEmp { get; set; }
        [JsonProperty("group_emp")]
        public int? GroupId { get; set; }
    }
    public class PayrollPeriodResponse : BaseViewModel<PayrollPeriod>
    {
        [JsonProperty("id")]
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
