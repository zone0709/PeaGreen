using DataCore.Models;
using DataCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tool01
{
    public class TimeSummaryService
    {

        public void AutoCheckTimeSummary()
        {
            using (var db = new Reso_PeaContext())
            {
                var listEmp = db.Employee.Where(p => p.IsActive == true);
                var listTimeMode = db.TimeMode.Where(t => t.IsActive == true).ToList();
                DateTime fromDate = new DateTime(2018, 6, 1);
                DateTime toDate = new DateTime(2018, 6, 30);
                //var listDayType = GetListDayType();
                foreach (var emp in listEmp)
                {

                    foreach (DateTime day in EachDay(fromDate, toDate))
                    {
                        //load list attendance. ĐK:
                        //+ isActive true
                        //+ có cùng mã nhân viên
                        //+ có cùng ngày duyệt
                        //+ status phải là accept
                        var listAttendance = db.Attendance.Where(att => att.IsActive == true
                                                                  && att.EmployeeId == emp.Id
                                                                  && att.Date == day
                                                                  && att.Status == (int)AttendanceStatusEnum.Accept).ToList();
                        if (listAttendance.Count() > 0)
                        {
                            //load ListDayType đang active và order theo priority từ Cao tới thấp (3 -> 1)
                            var listDayType = db.DayType.Where(d => d.IsActive == true).OrderByDescending(d => d.Priority).ToList();

                            //so sánh listDayType với ngày được chọn
                            var dayTypeSelected = CompareDayType(day, listDayType);
                            //listTimeMode theo ngày hôm đó tương ướng với DayType có độ ưu tiên cao nhất
                            if (dayTypeSelected != null)
                            {
                                var listTimeModeSelected = listTimeMode.Where(t => t.DayTypeId == dayTypeSelected.Id).ToList();

                                if (listTimeModeSelected.Count() > 0)
                                {
                                    var listResult = CreateTimeSummary(listAttendance, listTimeModeSelected);
                                    var listResultExisted = db.TimeSummary.Where(e => e.IsActive == true);

                                    if (listResult.Count > 0)
                                    {
                                        foreach (var result in listResult)
                                        {
                                            //Kiểm tra xem có tồn tại row đó chưa nếu tồn tại r thì chỉ việc update thôi không cần tạo lại

                                            var resultNeedUpdated = listResultExisted.Where(rs => rs.EmployeeId == result.EmployeeId
                                                                                         && rs.Date == result.Date
                                                                                         && rs.Status == (int)TimeSummaryEnum.Waiting).ToList();
                                            if (resultNeedUpdated.Count > 0)
                                            {
                                                db.TimeSummary.RemoveRange(resultNeedUpdated);
                                            }
                                            result.Status = (int)TimeSummaryEnum.Waiting;
                                            db.TimeSummary.Add(result);
                                        }
                                    }
                                }
                                else
                                {
                                    var resultExisted = db.TimeSummary.Where(rs => rs.EmployeeId == emp.Id
                                                                                        && rs.Date == day
                                                                                        && rs.Status == (int)TimeSummaryEnum.Waiting
                                                                                        && rs.IsActive == true).ToList();
                                    if (resultExisted.Count > 0)
                                    {
                                        db.TimeSummary.RemoveRange(resultExisted);
                                    }
                                }
                                db.SaveChanges();
                            }
                        }

                    }
                }

            }
        }
        public static DayType CompareDayType(DateTime daySelected, List<DayType> listDayType)
        {
            foreach (var dayType in listDayType)
            {
                if (dayType.DaysOfTheWeek != null && dayType.DaysOfTheWeek.Count() > 0)
                {
                    var listDayOfWeek = dayType.DaysOfTheWeek.Split('-').ToList();
                    foreach (var dayOfWeek in listDayOfWeek)
                    {
                        String dayOfWeekTimeMode = ((DaysOfWeekEnum)int.Parse(dayOfWeek)).ToString();
                        if (daySelected.DayOfWeek.ToString().Equals(dayOfWeekTimeMode))
                        {
                            return dayType;
                        }
                    }
                }
                else if (BetweenDate(daySelected, dayType.FromDate.GetValueOrDefault(), dayType.ToDate.GetValueOrDefault()))
                {
                    return dayType;
                }
            }
            return null;
        }

        public List<TimeSummary> CreateTimeSummary(List<Attendance> listAttendance, List<TimeMode> listTimeMode)
        {
            List<Attendance> listAttendanceSelected = new List<Attendance>();
            List<TimeSummary> listTimeSummary = new List<TimeSummary>();
            var employeeId = listAttendance.FirstOrDefault().EmployeeId;
            var date = listAttendance.FirstOrDefault().Date;
            foreach (var timeMode in listTimeMode)
            {
                listAttendanceSelected = new List<Attendance>();
                TimeSpan sum = new TimeSpan(0, 0, 0);
                for (int i = 0; i < listAttendance.Count; i++)
                {
                    var attendance = listAttendance[i];

                    //var duration = CompareTimespanAndCalculateDuration(attendance, timeMode);
                    var result = CompareTimespanAndCalculateDuration(attendance, timeMode);
                    sum += result;
                }
                if (sum.TotalSeconds > 0)
                {
                    listTimeSummary.Add(new TimeSummary
                    {
                        EmployeeId = employeeId.GetValueOrDefault(),
                        Date = date,
                        TimeModeId = timeMode.Id,
                        IsActive = true,
                        TotalHours = sum
                    });
                }
            }
            return listTimeSummary;
        }

        public TimeSpan CompareTimespanAndCalculateDuration(Attendance attendance, TimeMode timeMode)
        {
            // có cùng kiểu OT hay thường thì mới vào đây
            if (attendance.WorkingShiftType == timeMode.WorkingShiftType)
            {
                List<AttendanceTmp> listAttendanceTmpSelected = new List<AttendanceTmp>();
                TimeSpan duration = new TimeSpan(0, 0, 0);
                //Nếu attendance ko có checkmax mà vẫn được duyệt --> nó có mặt trong ca đó
                //--> Nên  lấy giờ kết thúc ca làm giờ check out cho nó luôn
                TimeSpan checkIn = new TimeSpan();
                TimeSpan checkOut = new TimeSpan();
                //Xác định giơ vào ra để tính giờ công cho nhân viên
                // trường hợp giờ ra của nhân viên ko có hoặc giơ ra năm trong khoảng time mercy => lấy giờ kết thúc ca để tính giờ công
                if (attendance.CheckMax == null || attendance.CheckMax.Value > attendance.ShiftMax)
                {
                    checkOut = attendance.ShiftMax.Value;
                }
                else
                {
                    checkOut = attendance.CheckMax.Value;
                }
                // trường hợp giờ vào ko có hoặc giơ vào năm trong khoảng time mercy => lấy giờ bắt đầu ca để tính giờ công
                if (attendance.CheckMin == null || attendance.CheckMin.Value < attendance.ShiftMin)
                {
                    checkIn = attendance.ShiftMin.Value;
                }
                else
                {
                    checkIn = attendance.CheckMin.Value;
                }
                if (BetweenTimeSpan(checkIn, timeMode.TimeStart.GetValueOrDefault(), timeMode.TimeEnd.GetValueOrDefault())
                    && BetweenTimeSpan(checkOut, timeMode.TimeStart.GetValueOrDefault(), timeMode.TimeEnd.GetValueOrDefault()))
                {
                    duration = checkOut.Subtract(checkIn);
                }
                else
                    if (checkIn <= timeMode.TimeStart.GetValueOrDefault()
                    && checkOut >= timeMode.TimeEnd.GetValueOrDefault())
                {
                    duration = timeMode.TimeEnd.GetValueOrDefault() - timeMode.TimeStart.GetValueOrDefault();
                }
                else
                    if (BetweenTimeSpan(checkIn, timeMode.TimeStart.GetValueOrDefault(), timeMode.TimeEnd.GetValueOrDefault()))
                {
                    duration = timeMode.TimeEnd.GetValueOrDefault().Subtract(checkIn);
                }
                else
                    if (BetweenTimeSpan(checkOut, timeMode.TimeStart.GetValueOrDefault(), timeMode.TimeEnd.GetValueOrDefault()))
                {
                    duration = checkOut.Subtract(timeMode.TimeStart.GetValueOrDefault());
                }
                return duration;
            }
            else
            {
                return new TimeSpan(0, 0, 0);
            }
        }

        public static bool BetweenTimeSpan(TimeSpan input, TimeSpan time1, TimeSpan time2)
        {
            return ((input > time1 && input < time2) || input == time1 || input == time2);
        }

        public static bool BetweenDate(DateTime input, DateTime date1, DateTime date2)
        {
            return (input > date1 && input < date2 || input == date1 || input == date2);
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
