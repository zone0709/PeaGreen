using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.Service
{
    public class FingerScanMachineService : BaseService<FingerScanMachine, FingerScanMachineBasic>, IFingerScanMachineService
    {
        public FingerScanMachineService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public FingerScanMachineBasic Get(int? storeId)
        {
           return  FirstOrDefault(p => (storeId == null || p.StoreId == storeId));
        }
    }
}
