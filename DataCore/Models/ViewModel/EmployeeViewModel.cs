using AutoMapper;
using DataCore.Models.Entities;
using Doitsu.Service.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.ViewModel
{
    public class EmployeeBasic : BaseViewModel<Employee>
    {
       

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        public EmployeeBasic() { }
        public EmployeeBasic(Employee entity, IMapper mapper) : base(entity, mapper) { }
    }
    public class EmployeeDetail : EmployeeBasic
    {
        
        [JsonProperty("birth_day")]
        public DateTime? DateOfBirth { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("brand_id")]
        [JsonIgnore]
        public int? BrandId { get; set; }
        [JsonProperty("role_name")]
        public List<string> RoleName { get; set; }
        [JsonProperty("salary_lvl")]
        public int SalaryLevelId { get; set; }
        //public string Pin { get; set; }
        public EmployeeDetail() { }
        public EmployeeDetail(Employee entity, IMapper mapper) : base(entity, mapper) { }
    }


    public class EmployeeRequest
    {
        [JsonProperty("emp_id")]
        int EmpId { get; set; }
    }

    public class PhoneRequest : EmployeeRequest
    {
        [JsonProperty("phone")]
        string Phone { get; set; }
    }
    public class AddressRequest : EmployeeRequest
    {
        [JsonProperty("address")]
        string Address { get; set; }
    }
    public class NameRequest : EmployeeRequest
    {
        [JsonProperty("name")]
        string Name { get; set; }
    }
    public class SexRequest : EmployeeRequest
    {
        [JsonProperty("sex")]
        bool Sex { get; set; }
    }
    public class BrandRequest : EmployeeRequest
    {
        [JsonProperty("brand_id")]
        int BrandId { get; set; }
    }
    public class JobRequest : EmployeeRequest
    {
        [JsonProperty("job_id")]
        int JobId { get; set; }
    }
}
