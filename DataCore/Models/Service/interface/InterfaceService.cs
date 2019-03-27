using DataCore.Models.Entities;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models.Service
{
    #region Employee 
    public interface IEmployeeGroupService : IBaseService<EmployeeGroup, EmployeeGroupBasic>
    {
        List<EmployeeGroupBasic> GetGroup();
    }

    public interface IEmployeeDetailService : IBaseService<Employee, EmployeeDetail>
    {
        Task<EmployeeDetail> GetDetailById(int id);
    }
    //public interface IEmployeeGroupMappingService : IBaseService<EmployeeGroupMapping, EmpGroupMappingModel>
    //{
    //    List<int> GetListEmp(int id);
    //}
    //public interface IEmployeeJobMappingService : IBaseService<EmployeeJobMapping, EmployeeJobMappingViewModel>
    //{
    //    List<int> GetByEmpId(int id);
    //}
    //public interface IEmployeeJobService : IBaseService<EmployeeJob, EmployeeJobBasic>
    //{
    //    IQueryable<EmployeeJobBasic> Get();
    //    List<string> GetRoleNameById(List<int> listid);
    //}

    public interface IEmployeeService : IBaseService<Employee, EmployeeBasic>
    {
        IQueryable<EmployeeBasic> Get(string email = null);
        EmployeeDetail Get(int id);
        void UpdatePatch(EmployeeUpdatePatch request);
        IQueryable<Employee> GetByGroupId(int id);
        bool Add(UserBasic model,string number);
    }
    #endregion

    #region DayMode
    public interface IDayModeService : IBaseService<DayMode, DayModeBasic>
    {
        List<DayofWeeks> GetDOW();
        List<DayModeBasic> Get();
        void CreateDayMode(DayModeCreateRequest request);
    }

    #endregion

    #region Payroll

    public interface IPayrollDetailService : IBaseService<PayrollDetail, PayrollDetailBasic>
    {
        void CreatePayrollDetail(PayrollDetailBasic model);
        IQueryable<PayrollDetail> GetPayrollDetail();

    }

    public interface IPayrollPeriodService : IBaseService<PayrollPeriod, PayrollPeriodBasic>
    {
        void CreatePeriod(PayrollPeriodBasic request);
        void ApplyPeriod(PayrollPeriodApply request);
        List<PayrollPeriodResponse> Get(int? empId);
    }

    public interface IPayrollDetailCategoryService : IBaseService<PayrollDetailCategory, PayrollDetailCategoryBasic>
    {
        List<PayrollDetailCategoryBasic> Get();
    }

    #endregion

    #region PaySlip
    public interface IPaySlipItemService : IBaseService<PaySlipItem, PaySlipItemBasic>
    {
        int Add(PaySlipItem entity);
    }
    public interface IPaySlipService : IBaseService<PaySlip, PaySlipBasic>
    {
        int Add(PaySlip entity);
        void AddListEmp(PaySlipEmp model);
        void AddGroupEmp(PaySlipGroupEmp model);
        void DeleteEmp(PaySlipEmp model);
        List<int> GetByEmpId(int empId);
    }
    public interface IPaySlipAttributeService : IBaseService<PayslipAttribute, PaySlipAttributeBasic>
    {
        IEnumerable<PayslipAttribute> Get();
    }
    public interface ITemplateDetailMappingService : IBaseService<TemplateDetailMapping, TemplateDetailMappingBasic>
    {
        void Remove(int id);
        void CreateTemplateMapping(TemplateDetailMappingBasic model);
        IEnumerable<PayrollDetail> GetPayrollByTemplateId(int id);
    }

    public interface IPaySlipTemplateService : IBaseService<PaySlipTemplate, PaySlipTemplateBasic>
    {
        void Remove(PaySlipRequestDelete request);
        void CreateTemplate(PaySlipTemplateBasic model);
        List<PaySlipTemplateResponse> Get();
        PaySlipTemplateDetailResponse Get(int id);
        PaySlipTemplate GetEById(int id);


    }
    #endregion

    #region TimeFrame

    public interface ITimeFrameService : IBaseService<TimeFrame, TimeFrameBasic>
    {
        List<TimeFrameBasic> Get();
        void Add(TimeFrameRequestCreate request);
        TimeFrameBasic GetById(int id);
    }

    #endregion

    #region Salary 

    public interface ISalaryRuleGroupService : IBaseService<SalaryRuleGroup, SalaryRuleGroupBasic>
    {
        List<SalaryRuleGroupBasic> Get();
    }
    //public interface ISalarylvlService : IBaseService<SalaryLevel, SalarylvlBasic>
    //{
    //    IQueryable<SalarylvlBasic> Get();
    //}

    public interface ISalaryRuleService : IBaseService<SalaryRule, SalaryRuleBasic>
    {
        List<SalaryRuleResponse> GetSalaryRule(SalaryQueryRequest request);
        void CreateSalaryRule(SalaryRuleBasic request);
    }

    #endregion

    #region TimeMode

    public interface ITimeModeService : IBaseService<TimeModeRule, TimeModeBasic>
    {
        List<TimeModeBasic> GetTimeModes();
        void CreateTimeMode(TimeModeBasic model);
    }

    #endregion

    #region ShiftRegister
    public interface IShiftRegisterService : IBaseService<ShiftRegister, ShiftRegisterBasic>
    {
        List<ShiftRegisterResponse> Get();
        void RegistShift(List<ShiftRegisterBasic> request);
        void Add(ShiftRegisterBasic requset);
        ShiftRegisterBasic GetById(int id);
        void Accept(int id);
    }

    #endregion

    #region Attendent

    public interface IAttendanceService : IBaseService<Attendance, AttendanceBasic>
    {
        List<AttendanceResponse> Get(AttendanceQueryRequest request);
        void Add(List<AttentdenceRequest> requests);
        void Accept(AttentdenceAcceptRequest request);
        List<AttendanceStatusResponse> GetStatus(AttendanceQueryRequest request);
    }

    #endregion

    #region CheckFinger
    public interface ICheckFingerService : IBaseService<CheckFinger, CheckFingerBasic>
    {
        void Add(CheckFingerBasic request);
    }
    #endregion

    #region FingerScanMachine
    public interface IFingerScanMachineService : IBaseService<FingerScanMachine, FingerScanMachineBasic>
    {
        FingerScanMachineBasic Get(int? storeId);
    }
    #endregion

    #region UserService
    public interface IUserService
    {
        Task Register(string brandToken, UserBasic model);
         Task<UserResponse> Login(string brandToken, UserLoginRequest model);
    }
    #endregion
}
