using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class EmpGroupMappingModel : BaseViewModel<EmployeeGroupMapping>
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeGroupId { get; set; }
    }
}
