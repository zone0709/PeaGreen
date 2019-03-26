using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public  class PaySlipItemBasic : BaseViewModel<PaySlipItem>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PaySlipId { get; set; }
        public int? PayrollDetailId { get; set; }
        public double? Value { get; set; }
        public bool Active { get; set; }
    }
}
