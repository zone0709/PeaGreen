using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class PaySlipAttributeBasic : BaseViewModel<PayslipAttribute>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int BrandId { get; set; }
        public string Code { get; set; }
    }
}
