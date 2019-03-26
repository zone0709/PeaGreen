using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataCore.Models.Service;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeaGreen.Controllers
{
    
    [Route("api/payroll_detail")]
    [ApiController]
    public class PayrollDetailController : ControllerBase, IPayrollDetailController
    {
        IPayrollDetailService payrollDetailService;
        IMapper mapper;
        public PayrollDetailController(IPayrollDetailService payrollDetailService,IMapper mapper)
        {
            this.payrollDetailService = payrollDetailService;
            this.mapper = mapper;
        }
        [HttpPost("")]
        public ActionResult Create(PayrollDetailBasic request)
        {
            payrollDetailService.CreatePayrollDetail(request);
            return Ok();
        }
        [HttpGet("")]
        public ActionResult<List<PayrollDetailResponse>> Get()
        {
            var result = payrollDetailService.GetPayrollDetail();
            if(result.Count() <= 0)
            {
                return NotFound();
            }
            var response = result.ProjectTo<PayrollDetailResponse>(mapper.ConfigurationProvider).ToList();
            return Ok(response);
        }
    }
}