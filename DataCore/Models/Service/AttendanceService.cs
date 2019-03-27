using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataCore.Models.Entities;
using DataCore.Models.Utilities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DataCore.Models.Service
{
    public class AttendanceService : BaseService<Attendance, AttendanceBasic>, IAttendanceService
    {
        readonly IEmployeeService employeeService;
        readonly ITimeFrameService timeFrameService;
        readonly IShiftRegisterService shiftRegisterService;
        public AttendanceService(
            IEmployeeService employeeService,
            ITimeFrameService timeFrameService,
            IShiftRegisterService shiftRegisterService,
            IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.employeeService = employeeService;
            this.timeFrameService = timeFrameService;
            this.shiftRegisterService = shiftRegisterService;
        }

        public void Accept(AttentdenceAcceptRequest request)
        {
            foreach (var item in request.ListShiftRegisterId)
            {
                var shift = shiftRegisterService.GetById(item);

                var timeFrame = timeFrameService.GetById(shift.TimeframeId.Value);
                var entity = new Attendance()
                {
                    EmployeeId = shift.EmployeeId,
                    Status = (int)StatusAttendanceEnum.Processing,
                    ShiftMin = shift.StartTime,
                    ShiftMax = shift.EndTime,
                    BrandId = timeFrame.BrandId,
                    StoreId = request.StoreId,
                    ProcessingStatus = (int)ProcessingStatusAttendenceEnum.Assign,
                    TimeFramId = shift.TimeframeId.Value,
                    Active = true,
                    ExpandTime = timeFrame.CheckInExpandTime.Value,
                    BreakTime = timeFrame.BreakTime,
                    InMode = timeFrame.InMode,
                    OutMode = timeFrame.OutMode,
                    CheckInExpandTime = timeFrame.CheckInExpandTime,
                    CheckOutExpandTime = timeFrame.CheckOutExpandTime,
                    ComeLateExpandTime = timeFrame.ComeLateExpandTime,
                    LeaveEarlyExpandTime = timeFrame.LeaveEarlyExpandTime
                };
                Create(entity);
                shiftRegisterService.Accept(item);
            }
        }

        public void Add(List<AttentdenceRequest> requests)
        {
            var trans = UnitOfWork.CreateTransac();
            try
            {

                foreach (var item in requests)
                {
                    var emp = employeeService.FindById(item.EmployeeId);
                    if (emp == null)
                    {
                        throw ApiException.Get(false, ConstantManager.NotFound("Employee "), ResultEnum.EmpNotFound, HttpStatusCode.NotFound);
                    }
                    var entity = Mapper.Map<AttentdenceRequest, Attendance>(item);
                    //item.ToEntity();
                    for (int i = 0; i < item.Dates.Count; i++)
                    {
                        entity.ShiftMax = item.Dates[i].GetStartOfDate().Add(item.ShiftMaxTime[i]);
                        entity.ShiftMin = item.Dates[i].GetStartOfDate().Add(item.ShiftMaxTime[i]);
                        entity.ExpandTime = new TimeSpan();
                        entity.CheckInExpandTime = new TimeSpan(1, 0, 0);
                        entity.CheckOutExpandTime = new TimeSpan(1, 0, 0);
                        entity.ComeLateExpandTime = new TimeSpan(1, 0, 0);
                        entity.LeaveEarlyExpandTime = new TimeSpan(1, 0, 0);
                        entity.ProcessingStatus = (int)ProcessingStatusAttendenceEnum.Assign;
                        var timeFrameId = item.TimeFramId[i];
                        var tf = timeFrameService.FindById(timeFrameId);
                        if (tf == null)
                        {
                            throw ApiException.Get(false, ConstantManager.NotFound("Time Frame "), ResultEnum.TimeFrameNotFound, HttpStatusCode.NotFound);
                        }
                        entity.TimeFramId = tf.Id;
                        entity.Active = true;
                        entity.Status = (int)StatusAttendanceEnum.Processing;
                        Create(entity);
                    }
                }
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Dispose();

                if (e is ApiException)
                {
                    throw e;
                }
                else
                {
                    ApiException.Get(false, ConstantManager.FAIL, ResultEnum.InternalError, HttpStatusCode.InternalServerError);
                }
            }

        }

        public List<AttendanceResponse> Get(AttendanceQueryRequest request)
        {
            var from = DateTime.Parse(request.FromDate).GetStartOfDate();
            var to = DateTime.Parse(request.ToDate).GetEndOfDate();
            return GetAsNoTracking(p => p.Active == true
            && (p.ShiftMin >= from && p.ShiftMax <= to)
            && (request.EmpId == null || p.EmployeeId == request.EmpId))
            .ProjectTo<AttendanceResponse>(Mapper.ConfigurationProvider).ToList();
        }

        public List<AttendanceStatusResponse> GetStatus(AttendanceQueryRequest request)
        {
            var from = DateTime.Parse(request.FromDate).GetStartOfDate();
            var to = DateTime.Parse(request.ToDate).GetEndOfDate();
            return GetAsNoTracking(p => p.Active == true
           && (p.ShiftMin >= from && p.ShiftMax <= to)
           && (request.EmpId == null || p.EmployeeId == request.EmpId))
             .Select(p => new AttendanceStatusResponse()
             {
                 Date = p.ShiftMax.Date,
                 // status  Assign false, UpdatedByAuto true,
                 Status = (p.CheckMin != null && p.CheckMax != null) ? true : false
             }).ToList();
        }

    }
}
