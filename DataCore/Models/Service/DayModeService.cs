using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore.Models.Service
{

    public class DayModeService : BaseService<DayMode, DayModeBasic>, IDayModeService
    {
        readonly IMapper mapper;
        public DayModeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.mapper = mapper;
        }

        public void CreateDayMode(DayModeCreateRequest request)
        {
            request.BrandId = 1;
            var dayFilter = 0;
            request.Active = true;
            foreach (var item in request.DaysOfTheWeek)
            {
                dayFilter += (int)Math.Pow(2, item);
            }
            var entity = Mapper.Map<DayModeCreateRequest, DayMode>(request);
            entity.DayFilter = dayFilter;
            Create(entity);
        }

        public List<DayModeBasic> Get()
        {
            var DayModeQuery = GetActiveAsNoTracking(d => d.Active == true);
            var listDayBasic = new List<DayModeBasic>();
            foreach (var item in DayModeQuery)
            {
                var dowa = new List<DayofWeeksActive>();
                foreach (DaysOfWeekEnum item2 in (DaysOfWeekEnum[])Enum.GetValues(typeof(DaysOfWeekEnum)))
                {
                    var id = (int)item2;
                    var day = new DayofWeeksActive()
                    {
                        Id = id,
                        Name = item2.ToString(),
                    };
                    var dayBit = (int)Math.Pow(2, id);
                    if ((item.DayFilter & dayBit) == dayBit)
                    {
                        day.Active = true;
                    }
                    else
                    {
                        day.Active = false;
                    }
                    dowa.Add(day);
                }
                var daybasic = new DayModeBasic(item, mapper)
                {
                    DayofWeek = dowa
                };

                listDayBasic.Add(daybasic);
            }
            return listDayBasic;
        }

        public List<DayofWeeks> GetDOW()
        {
            var dow = new List<DayofWeeks>();
            foreach (DaysOfWeekEnum item in (DaysOfWeekEnum[])Enum.GetValues(typeof(DaysOfWeekEnum)))
            {
                var id = (int)item;
                var day = new DayofWeeks()
                {
                    Id = id,
                    Name = item.ToString()
                };
                dow.Add(day);
            }
            return dow;
        }
    }
}
