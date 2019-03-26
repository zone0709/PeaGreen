using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models.Service
{
    
    public class TemplateDetailMappingService : BaseService<TemplateDetailMapping, TemplateDetailMappingBasic>, ITemplateDetailMappingService
    {
        public TemplateDetailMappingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void CreateTemplateMapping(TemplateDetailMappingBasic model)
        {
            model.IsActive = true;
            Create(model);
        }
        public void Remove(int id)
        {
            Delete(id);
        }

        public IEnumerable<PayrollDetail> GetPayrollByTemplateId(int id)
        {
            var result = GetAsNoTracking(p => p.PaySlipTemplateId == id).Select(a => a.PayrollDetail).AsEnumerable();
            return result;
        }
    }
}
