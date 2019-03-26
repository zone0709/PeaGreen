using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Models.Service
{
    public class CheckFingerService : BaseService<CheckFinger, CheckFingerBasic>, ICheckFingerService
    {
        readonly IFingerScanMachineService fingerScanMachineService;
        public CheckFingerService(IFingerScanMachineService fingerScanMachineService, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.fingerScanMachineService = fingerScanMachineService;
        }

        public void Add(CheckFingerBasic request)
        {
            var machine = fingerScanMachineService.Get(request.StoreId);
            var currentday = Utils.GetCurrentDateTime();
            request.FingerScanMachineId = machine.Id;
            request.MachineNumber = machine.MachineCode;
            request.LogCode = request.StoreId + "-" + machine.MachineCode + "-" + currentday.Ticks;
            request.DateTime = Convert.ToDateTime(currentday.ToString("MM/dd/yyyy HH:mm"));
            request.Active = true;
            request.IsUpdated = false;
            Create(request);
        }
    }
}
