using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class EmployeeJobMappingViewModel : BaseViewModel<EmployeeJobMapping>
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? EmployeeRoleId { get; set; }
        public bool? IsActive { get; set; }
    }
}
