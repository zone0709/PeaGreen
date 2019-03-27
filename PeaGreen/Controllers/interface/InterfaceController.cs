using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaGreen.Controllers
{
    #region Employee
    public interface IEmployeeGroupController
    {
        ActionResult<List<EmployeeGroupBasic>> Get();
    }
    //public interface IEmployeeJobController
    //{
    //    ActionResult<EmployeeJobBasic> Get();
    //}

    public interface IEmployeeController
    {
        ActionResult Get(int? EmployeeId);
        //Task<ActionResult<EmployeeDetail>> GetDetail(int id);
        //ActionResult Create(EmployeeBasic request);
        ActionResult Update(EmployeeBasic request);
        ActionResult UpdateName(NameRequest request);
        ActionResult UpdateAddress(AddressRequest request);
        //ActionResult UpdateBrand(BrandRequest request);
        ActionResult UpdatePhone(PhoneRequest request);
        //ActionResult UpdateSex(SexRequest request);
        //ActionResult UpdateJob(JobRequest request);


    }
    #endregion

    #region DayMode

    public interface IDayModeController
    {
        ActionResult<List<DayofWeeks>> GetDoW();
        ActionResult<List<DayModeBasic>> Get();
        ActionResult Create(DayModeCreateRequest request);
        ActionResult UpdateDate(DayModeDateRequest request);
        ActionResult UpdateDayOfWeek(DayModeDofWRequest request);
        ActionResult DeActive(DayModeDeActiveRequest request);

    }
    #endregion

    #region Payroll
    public interface IPayrollDetailController
    {
        ActionResult Create(PayrollDetailBasic request);
        ActionResult<List<PayrollDetailResponse>> Get();
    }

    public interface IPayrollPeriodController
    {
        ActionResult Create(PayrollPeriodBasic request);
        ActionResult Apply(PayrollPeriodApply request);
        ActionResult<List<PayrollPeriodResponse>> Get(int? emp_id);
    }
    public interface IPayrollDetailCategoryController
    {
        ActionResult Get();
    }

    #endregion

    #region TimeMode
    public interface ITimeModeController
    {
        ActionResult<List<TimeModeBasic>> Get();
        ActionResult Create(TimeModeBasic request);
        ActionResult Update(TimeModeBasic request);
        ActionResult DeActive(int id);
        ActionResult UpdateTime(TimeModeTimeRequest request);
    }
    #endregion

    #region User

    public interface IUserController
    {
        Task<ActionResult> Login(UserLoginRequest request);
        ActionResult Register(UserBasic request);
        ActionResult ResetPassword(string email);

    }
    #endregion

    #region PaySlip

    public interface IPaySlipTemplateController
    {
        ActionResult Create(PaySlipTemplateBasic request);
        ActionResult Get(int? id);
        ActionResult Delete(PaySlipRequestDelete request);

    }
    public interface IPaySlipController
    {
        ActionResult<List<PaySlipEmpBasic>> Get();

        ActionResult AddEmp(PaySlipEmp request);
        ActionResult AddEmpGroup(PaySlipGroupEmp request);

        ActionResult Update(PaySlipBasic request);

        ActionResult DeActive(int id);
    }

    #endregion

    #region Salary

    public interface ISalaryRuleController
    {
        ActionResult Get(SalaryQueryRequest request);
        ActionResult Create(SalaryRuleBasic request);
    }

    public interface ISalaryRuleGroupController
    {
        ActionResult<List<SalaryRuleGroupBasic>> Get();
    }

    //public interface ISalaryLevelController
    //{
    //    ActionResult<List<SalarylvlBasic>> Get();
    //    ActionResult Create(SalarylvlBasic request);
    //    ActionResult UpdateName(SalarylvlNameRequest request);
    //    ActionResult UpdateValue(ValueRequest request);
    //    ActionResult DeActive(DeActiveRequest request);
    //}
    #endregion

    #region TimeFrame
    public interface ITimeFrameController
    {
        ActionResult Get();
        ActionResult Create(TimeFrameRequestCreate request);
    }


    #endregion

    #region ShiftRegister
    public interface IShiftRegisterController
    {
        ActionResult Get();
        ActionResult Add(List<ShiftRegisterBasic> request);
    }
    #endregion

    #region Attendance
    public interface IAttendanceController
    {
        ActionResult Get(AttendanceQueryRequest request);
        ActionResult Add(List<AttentdenceRequest> requests);
        ActionResult Accept(AttentdenceAcceptRequest request);
        ActionResult GetStatus([FromQuery]AttendanceQueryRequest request);

    }
    #endregion

    #region CheckFinger
    public interface ICheckFingerController
    {
        ActionResult Add(CheckFingerBasic request);
    }
    #endregion


}
