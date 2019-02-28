using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class PaySlipBasic : BaseViewModel<PaySlip>
    {
        public int Id { get; set; }
        public int? PayrollPeriodId { get; set; }
        public int EmployeeId { get; set; }
        public double? NetPay { get; set; }
        public bool? IsActive { get; set; }
    }
  
    public class PaySlipEmp
    {
        public int Id { get; set; }
        public List<int> EmpId { get; set; }
    }
    public class PaySlipGroupEmp
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
    }
    public class PaySlipEmpBasic
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? PaySlipSessionId { get; set; }
        public double? Amount { get; set; }
        public PaySlipBasic PaySlipSession { get; set; }
    }
}
