using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.Service
{
    public class PaySlipItemService : BaseService<PaySlipItem, PaySlipItemBasic> , IPaySlipItemService
    {
        public PaySlipItemService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public int Add(PaySlipItem entity)
        {
            entity.Active = true;
            entity = Create(entity);
            return entity.Id;
        }
    }
}
