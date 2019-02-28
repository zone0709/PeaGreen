using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Attendance = new HashSet<Attendance>();
            AttendanceTmp = new HashSet<AttendanceTmp>();
            EmployeeAttributeMapping = new HashSet<EmployeeAttributeMapping>();
            EmployeeGroupMapping = new HashSet<EmployeeGroupMapping>();
            EmployeeJobMapping = new HashSet<EmployeeJobMapping>();
            EmployeeWorkingShiftAutoMapping = new HashSet<EmployeeWorkingShiftAutoMapping>();
            EmployeeWorkingShiftRegitser = new HashSet<EmployeeWorkingShiftRegitser>();
            PaySlip = new HashSet<PaySlip>();
            TimeSummary = new HashSet<TimeSummary>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int SalaryLevelId { get; set; }
        public string Pin { get; set; }
        public bool IsActive { get; set; }

        public virtual SalaryLevel SalaryLevel { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<AttendanceTmp> AttendanceTmp { get; set; }
        public virtual ICollection<EmployeeAttributeMapping> EmployeeAttributeMapping { get; set; }
        public virtual ICollection<EmployeeGroupMapping> EmployeeGroupMapping { get; set; }
        public virtual ICollection<EmployeeJobMapping> EmployeeJobMapping { get; set; }
        public virtual ICollection<EmployeeWorkingShiftAutoMapping> EmployeeWorkingShiftAutoMapping { get; set; }
        public virtual ICollection<EmployeeWorkingShiftRegitser> EmployeeWorkingShiftRegitser { get; set; }
        public virtual ICollection<PaySlip> PaySlip { get; set; }
        public virtual ICollection<TimeSummary> TimeSummary { get; set; }
    }
}
