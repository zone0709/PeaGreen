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
        public string Name { get; set; }
        [JsonProperty("code")]
        public string EmpEnrollNumber { get; set; }
        public EmployeeBasic() { }
        public EmployeeBasic(Employee entity, IMapper mapper) : base(entity, mapper) { }
    }
    public class EmployeeDetail : EmployeeBasic
    {

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("salary")]
        public decimal? Salary { get; set; }
        //public string Pin { get; set; }
        public EmployeeDetail() { }
        public EmployeeDetail(Employee entity, IMapper mapper) : base(entity, mapper) { }
    }


    public class EmployeeRequest
    {
        [JsonProperty("emp_id")]
        public int EmpId { get; set; }
    }

    public class PhoneRequest : EmployeeRequest
    {
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
    public class AddressRequest : EmployeeRequest
    {
        [JsonProperty("address")]
        public string Address { get; set; }
    }
    public class NameRequest : EmployeeRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class SexRequest : EmployeeRequest
    {
        [JsonProperty("sex")]
        public bool Sex { get; set; }
    }
    public class BrandRequest : EmployeeRequest
    {
        [JsonProperty("brand_id")]
        public int BrandId { get; set; }
    }
    public class JobRequest : EmployeeRequest
    {
        [JsonProperty("job_id")]
        public int JobId { get; set; }
    }
    public class EmployeeUpdatePatch : EmployeeRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool? Sex { get; set; }
        public int? BrandId { get; set; }
        public int? JobId { get; set; }
        public string Phone { get; set; }
    }
}
