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
    
    public class TimeModeService : BaseService<TimeModeRule, TimeModeBasic>, ITimeModeService
    {
        public TimeModeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void CreateTimeMode(TimeModeBasic model)
        {
            model.IsActive = true;
            model.DateCreate = Utils.GetCurrentDateTime();
            Create(model);
        }

        public List<TimeModeBasic> GetTimeModes()
        {
            return   GetAll().ToList();
        }
    }
}
