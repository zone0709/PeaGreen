using DataCore.Models.Entities;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class WorkingShiftBasic /*: BaseViewModel<WorkingShift>*/
    {
        public int Id { get; set; }
        public string WorkingShiftName { get; set; }
        public int? WorkingShiftType { get; set; }
        public TimeSpan? ShiftMin { get; set; }
        public TimeSpan? ShiftMax { get; set; }
        public TimeSpan? ExpandTime { get; set; }
        //public bool IsActive { get; set; }
        public int EmployeeId { get; set; }
    }
}
