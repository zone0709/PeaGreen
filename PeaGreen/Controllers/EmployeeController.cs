using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCore.Models.Entities;
using DataCore.Models.Service;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeaGreen.Controllers
{
    public interface IEmployeeController
    {
        ActionResult<List<EmployeeBasic>> Get();
        Task<ActionResult<EmployeeDetail>> GetDetail(int id);
        ActionResult Create(EmployeeBasic request);
        ActionResult Update(EmployeeBasic request);
        ActionResult UpdateName(NameRequest request);
        ActionResult UpdateAddress(AddressRequest request);
        ActionResult UpdateBrand(BrandRequest request);
        ActionResult UpdatePhone(PhoneRequest request);
        ActionResult UpdateSex(SexRequest request);
        ActionResult UpdateJob(JobRequest request);


    }
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase, IEmployeeController
    {
        IEmployeeService employeeService;
        IEmployeeDetailService employeeDetailService;

        public EmployeeController(IEmployeeService employeeService, IEmployeeDetailService employeeDetailService)
        {
            this.employeeService = employeeService;
            this.employeeDetailService = employeeDetailService;
        }

        [HttpPost,Route("")]
        public ActionResult Create(EmployeeBasic request)
        {
            return Ok(request);
        }

        [HttpGet("")]
        public ActionResult<List<EmployeeBasic>> Get()
        {
            var empQ = employeeService.Get();
            return Ok(empQ.ToList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetail>> GetDetail(int id)
        {
            var empDetailQ = employeeDetailService.GetDetailById(id);
            return Ok(await empDetailQ);
        }

        [HttpPut, Route("")]
        public ActionResult Update(EmployeeBasic request)
        {
            return Ok();
        }
        [HttpPatch,Route("address")]
        public ActionResult UpdateAddress(AddressRequest request)
        {
            return Ok();
        }

        [HttpPatch,Route("brand")]
        public ActionResult UpdateBrand(BrandRequest request)
        {
            return Ok();
            throw new NotImplementedException();
        }
        [HttpPatch,Route("job")]
        public ActionResult UpdateJob(JobRequest request)
        {
            return Ok();
            throw new NotImplementedException();
        }

        [HttpPatch, Route("name")]
        public ActionResult UpdateName(NameRequest request)
        {
            return Ok();
            throw new NotImplementedException();
        }

        [HttpPatch, Route("phone")]
        public ActionResult UpdatePhone(PhoneRequest request)
        {
            return Ok();
            throw new NotImplementedException();
        }

        [HttpPatch, Route("sex")]
        public ActionResult UpdateSex(SexRequest request)
        {
            return Ok();
            throw new NotImplementedException();
        }
    }
}