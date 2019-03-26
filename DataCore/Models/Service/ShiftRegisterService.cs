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
    public class ShiftRegisterService : BaseService<ShiftRegister, ShiftRegisterBasic>, IShiftRegisterService
    {
        readonly IMapper mapper;
        public ShiftRegisterService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.mapper = mapper;
        }


        public List<ShiftRegisterResponse> Get()
        {
            return GetAsNoTracking(p => p.Active == true)
                  .Select(a => new ShiftRegisterResponse(a, mapper)
                  {
                      EmpName = a.Employee.Name,
                      StartTimeVM = /*new TimeSpan(a.StartTime.Hour, a.StartTime.Minute, 0)*/ a.StartTime.TimeOfDay,
                      EndTimeVM = /*new TimeSpan(a.EndTime.Hour, a.EndTime.Minute, 0)*/ a.EndTime.TimeOfDay,
                      StartDate = a.StartTime.Date,
                      EndDate = a.EndTime.Date,
                      StatusName = ((ShiftRegisterEnum)a.Status).DisplayName()
                  }).ToList();
        }

        public void Add(ShiftRegisterBasic requset)
        {
            requset.Status = (int)ShiftRegisterEnum.Watting;
            requset.Active = true;
            Create(requset);
        }

        public ShiftRegisterBasic GetById(int id)
        {
            return FindById(id);
        }
        public void Accept(int id)
        {
            var entity = FindEById(id);
            entity.Status = (int)ShiftRegisterEnum.Accept;
            //var entity = GetAsNoTracking(p => p.Id == id && p.Active == true).FirstOrDefault();
            //entity.Status = (int)ShiftRegisterEnum.Accept;
            this.UnitOfWork.Commit();
            //Update(basic);
        }
        public void RegistShift(List<ShiftRegisterBasic> request)
        {

            var listMergeTimeRegister = new Dictionary<string, ShiftRegisterBasic>();
            var countUpdate = 0;
            var countNew = 0;
            var listSolveTimeConflict = new List<DateTime>();
            foreach (var item in request)
            {
                var date = item.StartTime.Date;
                var currentRegister = GetAsNoTracking(p => p.StartTime.Date <= date.GetStartOfDate()
                && p.EndTime.Date >= date.GetEndOfDate() && p.EmployeeId == item.EmployeeId)
                .Where(q => (item.StartTime >= q.StartTime && item.StartTime < q.EndTime) ||
                    (item.EndTime >= q.StartTime && item.EndTime < q.EndTime) ||
                    (item.StartTime >= q.StartTime && item.EndTime <= q.EndTime) ||
                    (item.StartTime <= q.StartTime && item.EndTime >= q.EndTime));
                //Nếu đã đăng ký nhưng muốn sửa lại
                if (currentRegister.Any())
                {
                    foreach (var current in currentRegister)
                    {
                        var registerModel = new ShiftRegisterBasic(current, mapper);
                        if (!listMergeTimeRegister.Any(q => q.Value.Equals(registerModel)))
                        {
                            ++countUpdate;
                            listMergeTimeRegister.Add("Delete" + countUpdate, registerModel);
                        }
                    }
                }

                //Trùng ngày
                if (listMergeTimeRegister.Values.Any(q => q.StartTime.Date == date))
                {
                    var conflictRegister = listMergeTimeRegister
                        .Where(q => (item.StartTime >= q.Value.StartTime && item.StartTime < q.Value.EndTime) ||
                        (item.EndTime >= q.Value.StartTime && item.EndTime < q.Value.EndTime) ||
                        (item.StartTime >= q.Value.StartTime && item.EndTime <= q.Value.EndTime) ||
                        (item.StartTime <= q.Value.StartTime && item.EndTime >= q.Value.EndTime))
                        .ToList();

                    //Trùng khoảng giờ thì fix lại start-end của item
                    if (conflictRegister.Any())
                    {
                        foreach (var conflict in conflictRegister)
                        {
                            listSolveTimeConflict.Add(conflict.Value.StartTime);
                            listSolveTimeConflict.Add(conflict.Value.EndTime);
                        }
                        listSolveTimeConflict.Add(item.StartTime);
                        listSolveTimeConflict.Add(item.EndTime);
                        listSolveTimeConflict = listSolveTimeConflict.OrderBy(q => q.Ticks).ToList();
                        item.StartTime = listSolveTimeConflict.FirstOrDefault();
                        item.EndTime = listSolveTimeConflict.LastOrDefault();

                        //Nếu đã có add mới => xóa tất cả và add lại
                        var checkNew = conflictRegister.Any(q => q.Key.Contains("Add"));
                        if (checkNew)
                        {
                            conflictRegister = conflictRegister.Where(q => q.Key.Contains("Add")).ToList();
                            foreach (var conflict in conflictRegister)
                            {
                                listMergeTimeRegister.Remove(conflict.Key);
                            }
                        }
                        //Add lại item
                        ++countNew;
                        listMergeTimeRegister.Add("Add" + countNew, item);
                    }
                    //Khác khoảng giờ
                    else
                    {
                        ++countNew;
                        listMergeTimeRegister.Add("Add" + countNew, item);
                    }
                }
                //Khác ngày
                else
                {
                    ++countNew;
                    listMergeTimeRegister.Add("Add" + countNew, item);
                }
            }
            var trans = UnitOfWork.CreateTransac();
            try
            {

                foreach (var item in listMergeTimeRegister)
                {

                    if (item.Key.Contains("Delete"))
                    {
                        item.Value.Active = false;
                        Update(item.Value.Id, item.Value);
                    }
                    else
                    {
                        item.Value.Status = (int)StatusAttendanceEnum.Processing;
                        item.Value.Active = true;
                        Create(item.Value);
                    }

                }
                trans.Commit();

            }
            catch (Exception e)
            {
                trans.Dispose();
                throw e;
            }
        }

        //public ActionResult AsignSchedulers(CreateShiftRegisterViewModel model, int brandId, int storeId)
        //{
        //    var registerApi = new ShiftRegisterApi();
        //    var timeframeApi = new TimeFrameApi();
        //    var listMergeTimeRegister = new Dictionary<string, ShiftRegisterViewModel>();
        //    var listSolveTimeConflict = new List<DateTime>();
        //    var result = false;
        //    var countUpdate = 0;
        //    var countNew = 0;

        //    foreach (var item in model.listRegister)
        //    {
        //        var date = item.StartTime.Date;
        //        var currentRegister = registerApi
        //            .GetShiftRegisterByTimeRangeByEmpId(date.GetStartOfDate(), date.GetEndOfDate(), item.EmployeeId)
        //            .Where(q => (item.StartTime >= q.StartTime && item.StartTime < q.EndTime) ||
        //            (item.EndTime >= q.StartTime && item.EndTime < q.EndTime) ||
        //            (item.StartTime >= q.StartTime && item.EndTime <= q.EndTime) ||
        //            (item.StartTime <= q.StartTime && item.EndTime >= q.EndTime));
        //        //Nếu đã đăng ký nhưng muốn sửa lại
        //        if (currentRegister.Any())
        //        {
        //            foreach (var current in currentRegister)
        //            {
        //                var registerModel = new ShiftRegisterViewModel(current);
        //                if (!listMergeTimeRegister.Any(q => q.Value.Equals(registerModel)))
        //                {
        //                    ++countUpdate;
        //                    listMergeTimeRegister.Add("Delete" + countUpdate, registerModel);
        //                }
        //            }
        //        }
        //        //Trùng ngày
        //        if (listMergeTimeRegister.Values.Any(q => q.StartTime.Date == date))
        //        {
        //            var conflictRegister = listMergeTimeRegister
        //                .Where(q => (item.StartTime >= q.Value.StartTime && item.StartTime < q.Value.EndTime) ||
        //                (item.EndTime >= q.Value.StartTime && item.EndTime < q.Value.EndTime) ||
        //                (item.StartTime >= q.Value.StartTime && item.EndTime <= q.Value.EndTime) ||
        //                (item.StartTime <= q.Value.StartTime && item.EndTime >= q.Value.EndTime))
        //                .ToList();

        //            //Trùng khoảng giờ thì fix lại start-end của item
        //            if (conflictRegister.Any())
        //            {
        //                foreach (var conflict in conflictRegister)
        //                {
        //                    listSolveTimeConflict.Add(conflict.Value.StartTime);
        //                    listSolveTimeConflict.Add(conflict.Value.EndTime);
        //                }
        //                listSolveTimeConflict.Add(item.StartTime);
        //                listSolveTimeConflict.Add(item.EndTime);
        //                listSolveTimeConflict = listSolveTimeConflict.OrderBy(q => q.Ticks).ToList();
        //                item.StartTime = listSolveTimeConflict.FirstOrDefault();
        //                item.EndTime = listSolveTimeConflict.LastOrDefault();

        //                //Nếu đã có add mới => xóa tất cả và add lại
        //                var checkNew = conflictRegister.Any(q => q.Key.Contains("Add"));
        //                if (checkNew)
        //                {
        //                    conflictRegister = conflictRegister.Where(q => q.Key.Contains("Add")).ToList();
        //                    foreach (var conflict in conflictRegister)
        //                    {
        //                        listMergeTimeRegister.Remove(conflict.Key);
        //                    }
        //                }
        //                //Add lại item
        //                ++countNew;
        //                listMergeTimeRegister.Add("Add" + countNew, item);
        //            }
        //            //Khác khoảng giờ
        //            else
        //            {
        //                ++countNew;
        //                listMergeTimeRegister.Add("Add" + countNew, item);
        //            }
        //        }
        //        //Khác ngày
        //        else
        //        {
        //            ++countNew;
        //            listMergeTimeRegister.Add("Add" + countNew, item);
        //        }
        //    }

        //    foreach (var item in listMergeTimeRegister)
        //    {
        //        try
        //        {
        //            if (item.Key.Contains("Delete"))
        //            {
        //                item.Value.Active = false;
        //                registerApi.Edit(item.Value.Id, item.Value);
        //            }
        //            else
        //            {
        //                item.Value.Status = (int)ShiftRegisterStatus.Processing;
        //                item.Value.Active = true;
        //                registerApi.Create(item.Value);
        //            }
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
}
