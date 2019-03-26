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
    public class TimeFrameService : BaseService<TimeFrame, TimeFrameBasic>, ITimeFrameService
    {
        IMapper mapper;
        public TimeFrameService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.mapper = mapper;
        }

        public void Add(TimeFrameRequestCreate request)
        {
            request.Duration = request.EndTime-request.StartTime;
            request.Active = true;
            var entity = mapper.Map<TimeFrameRequestCreate, TimeFrame>(request);
            entity.CheckInExpandTime = new TimeSpan(1, 0, 0);
            entity.CheckOutExpandTime = new TimeSpan(1, 0, 0);
            entity.ComeLateExpandTime = new TimeSpan(1, 0, 0);
            entity.LeaveEarlyExpandTime = new TimeSpan(1, 0, 0);
            Create(entity);
        }

        public List<TimeFrameBasic> Get()
        {
            return  GetAll().ToList();
        }
        public TimeFrameBasic GetById(int id)
        {
            return FindById(id);
        } 
    }


    //public ActionResult CreateMoreAttendanceActionByDateRangeForOne(int brandId, int empId, int storeId, List<string> shiftMin, List<string> shiftMax, List<string> dateList, 
    // List<int> timeFrameId, List<int> inMode, List<int> outMode, List<string> checkinExpandtime, List<string> checkoutExpandtime, List<string> breaktime, 
    // List<string> comelateExpandtime, List<string> leaveearlyExpandtime)
    //{
    //    var attendanceApi = new AttendanceApi();
    //    var timeframeApi = new TimeFrameApi();

    //    bool result = false;
    //    for (int i = 0; i < dateList.Count; i++)
    //    {
    //        try
    //        {
    //            var attendance = new Attendance();
    //            attendance.EmployeeId = empId;
    //            attendance.StoreId = storeId;
    //            attendance.Status = (int)StatusAttendanceEnum.Processing;
    //            attendance.ShiftMin = dateList[i].ToDateTime().GetStartOfDate().Add(Utils.ToHourTime(shiftMin[i]).TimeOfDay);
    //            attendance.ShiftMax = dateList[i].ToDateTime().GetStartOfDate().Add(Utils.ToHourTime(shiftMax[i]).TimeOfDay);
    //            attendance.ProcessingStatus = (int)ProcessingStatusAttendenceEnum.Assign;
    //            attendance.TimeFramId = timeFrameId[i];
    //            attendance.ExpandTime = timeframeApi.Get(timeFrameId[i]).CheckInExpandTime.Value;
    //            attendance.BreakTime = Utils.ToHourTime(breaktime[i]).TimeOfDay;
    //            attendance.Active = true;
    //            attendance.InMode = inMode[i];
    //            attendance.OutMode = outMode[i];
    //            attendance.CheckInExpandTime = Utils.ToHourTime(checkinExpandtime[i]).TimeOfDay;
    //            attendance.CheckOutExpandTime = Utils.ToHourTime(checkoutExpandtime[i]).TimeOfDay;
    //            attendance.ComeLateExpandTime = Utils.ToHourTime(comelateExpandtime[i]).TimeOfDay;
    //            attendance.LeaveEarlyExpandTime = Utils.ToHourTime(leaveearlyExpandtime[i]).TimeOfDay;
    //            attendance.BrandId = brandId;
    //            attendanceApi.BaseService.Create(attendance);
    //            result = true;
    //        }
    //        catch (Exception e)
    //        {
    //            result = false;
    //        }
    //    }
    //    return Json(result);
    //}
}
