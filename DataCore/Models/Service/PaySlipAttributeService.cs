using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore.Models.Service
{
    public class PaySlipAttributeService : BaseService<PayslipAttribute, PaySlipAttributeBasic>, IPaySlipAttributeService
    {
        public PaySlipAttributeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IEnumerable<PayslipAttribute> Get()
        {
            var result = GetAsNoTracking(p => p.Active == true).AsEnumerable();
            return result;
        }
    }
}
