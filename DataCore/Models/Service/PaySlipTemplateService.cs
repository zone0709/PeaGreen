using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore.Models.Service
{

    public class PaySlipTemplateService : BaseService<PaySlipTemplate, PaySlipTemplateBasic>, IPaySlipTemplateService
    {
        ITemplateDetailMappingService templateMappingService;
        IPayrollDetailService payrollDetailService;
        readonly IMapper mapper;
        public PaySlipTemplateService(IPayrollDetailService payrollDetailService, ITemplateDetailMappingService templateMappingService, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.templateMappingService = templateMappingService;
            this.payrollDetailService = payrollDetailService;
            this.mapper = mapper;
        }

        public void CreateTemplate(PaySlipTemplateBasic model)
        {
            var listId = model.ListIdPayrollDetail;
            model.Active = true;
            model.BrandId = 1;
            model = Create(model);
            foreach (var item in listId)
            {
                var mapping = new TemplateDetailMappingBasic()
                {
                    PaySlipTemplateId = model.Id,
                    PayrollDetailId = item,
                };
                templateMappingService.CreateTemplateMapping(mapping);
            }
        }
        public PaySlipTemplate GetEById(int id)
        {
            var entity = FirstOrDefaultE(p => p.Active == true && p.Id == id);
            return entity;
        }

        public List<PaySlipTemplateResponse> Get()
        {
            var result = GetAsNoTracking(p => p.Active == true).ProjectTo<PaySlipTemplateResponse>(Mapper.ConfigurationProvider).ToList();
            return result;
        }

        public PaySlipTemplateDetailResponse Get(int id)
        {
            var payrollQ = payrollDetailService.GetPayrollDetail().ToList();
            var payrollQCheck = templateMappingService.GetPayrollByTemplateId(id).ToList();
            var listparoll = payrollQ.Select(a => new PayrollDetailCheckResponse(a, mapper)
            {
                Check = payrollQCheck.Any(p => p.Id == a.Id) ? true : false
            }).ToList();
            var entity = GetAsNoTracking(t => t.Id == id).First();
            var result = new PaySlipTemplateDetailResponse(entity, mapper)
            {
                ListPayrollDetail = listparoll
            };
            return result;
        }
        public void Remove(PaySlipRequestDelete request)
        {
            foreach (var item in request.ListId)
            {
                var listTemplateDetail = GetAsNoTracking(p => p.Active == true && p.Id == item).Select(p => p.TemplateDetailMapping).FirstOrDefault();
                foreach (var item2 in listTemplateDetail)
                {
                    templateMappingService.Remove(item2.Id);
                }
                Delete(item);
            }
        }
    }
}
