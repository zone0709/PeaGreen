
using System;
using AutoMapper;
using DataCore.Models.Entities;
using DataCore.Models.Service;
using DataCore.Models.ViewModel;
using Doitsu.Service.Core;
using Doitsu.Service.Core.AuthorizeBuilder;
using Doitsu.Service.Core.IdentitiesExtension;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataCore
{
    /// <summary>
    /// Is the api endpoint config to help build a web app fastly
    /// The core destination is: 
    /// + Config Identity with JWT
    /// + Config Main DB context
    /// + Config Service Dependency
    /// + Config Repo Dependency
    /// + Config Autmapper
    /// How to use:
    /// + Use should add to your config
    /// ++ Doitsu.Identity.DevDB key, value
    /// ++ Doitsu.Ecommerce.DevDB key, value
    /// </summary>
    public static class RootConfig
    {


        public static void Entry(IServiceCollection services, IConfiguration configuration)
        {
            //Doitsu.Identity.DBConStr
            #region Main Database Config
            // Config db context basic
            services.AddDbContext<Reso_PeaContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DBContext")));
            //// Config identity db config
            //services.AddDbContext<IdentityFandomContext>(options =>
            //                options.UseSqlServer(configuration.GetConnectionString("Doitsu.Identity.DBConStr")));

            //services.AddIdentity<DoitsuUserInt, IdentityRole<int>>()
            //    .AddEntityFrameworkStores<IdentityFandomContext>()
            //    .AddDefaultTokenProviders();

            services.AddScoped(typeof(DbContext), typeof(Reso_PeaContext));
            //services.AddScoped(typeof(IdentityDbContext<DoitsuUserInt, IdentityRole<int>, int>), typeof(IdentityFandomContext));
            //services.AddScoped(typeof(UserManager<DoitsuUserInt>), typeof(DoitsuUserIntManager));
            services.AddScoped(typeof(DoitsuUserIntManager));
            //services.AddScoped(typeof(UserManager<IdentityUser<int>>), typeof(DoitsuUserIntManager));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            DoitsuJWTServiceBuilder.BuildJWTService(services);
            #endregion

            #region DI Config
            
            #region Salary
            // SalarylvlService
            //services.AddScoped(typeof(ISalarylvlService), typeof(SalarylvlService));
            // SalaryRuleService
            services.AddScoped(typeof(ISalaryRuleService), typeof(SalaryRuleService));
            // SalaryRuleGroupService
            services.AddScoped(typeof(ISalaryRuleGroupService), typeof(SalaryRuleGroupService));

            #endregion 

            #region Employee
            // EmployeeGroupService
            services.AddScoped(typeof(IEmployeeGroupService), typeof(EmployeeGroupService));

            // EmployeeService
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
            // EmployeeJobMappingService
            //services.AddScoped(typeof(IEmployeeJobMappingService), typeof(EmployeeJobMappingService));
            // EmployeeDetailService
            //services.AddScoped(typeof(IEmployeeDetailService), typeof(EmployeeDetailService));
            //// EmployeeGroupMappingService
            //services.AddScoped(typeof(IEmployeeGroupMappingService), typeof(EmployeeGroupMappingService));
            //// EmployeeJobService
            //services.AddScoped(typeof(IEmployeeJobService), typeof(EmployeeJobService));
            #endregion

            #region DayMode
            // DayModeService
            services.AddScoped(typeof(IDayModeService), typeof(DayModeService));
            #endregion

            #region Payroll

            // PayrollPeriodService
            services.AddScoped(typeof(IPayrollPeriodService), typeof(PayrollPeriodService));
            // PayrollDetailService
            services.AddScoped(typeof(IPayrollDetailService), typeof(PayrollDetailService));
            // PayrollDetailCategoryService
            services.AddScoped(typeof(IPayrollDetailCategoryService), typeof(PayrollDetailCategoryService));

            #endregion

            #region TimeFrame
            //TimeFrameService
            services.AddScoped(typeof(ITimeFrameService), typeof(TimeFrameService));


            #endregion

            #region PaySlip
            // PaySlipService
            services.AddScoped(typeof(IPaySlipService), typeof(PaySlipService));
            // PaySlipTemplateService
            services.AddScoped(typeof(IPaySlipTemplateService), typeof(PaySlipTemplateService));
            // PaySlipItemService
            services.AddScoped(typeof(IPaySlipItemService), typeof(PaySlipItemService));
            //PaySlipTemplateMappingService
            services.AddScoped(typeof(ITemplateDetailMappingService), typeof(TemplateDetailMappingService));
            // PaySlipAttributeService
            services.AddScoped(typeof(IPaySlipAttributeService), typeof(PaySlipAttributeService));

            #endregion

            #region TimeMode
            //TimeModeService
            services.AddScoped(typeof(ITimeModeService), typeof(TimeModeService));
            #endregion

            #region Attendance
            //AttendanceService
            services.AddScoped(typeof(IAttendanceService), typeof(AttendanceService));
            #endregion

            #region ShiftRegister
            //ShiftRegisterService
            services.AddScoped(typeof(IShiftRegisterService), typeof(ShiftRegisterService));
            #endregion

            #region  CheckFinger
            //CheckFingerService
            services.AddScoped(typeof(ICheckFingerService), typeof(CheckFingerService));

            #endregion

            #region FingerScanMachine
            //FingerScanMachineService
            services.AddScoped(typeof(IFingerScanMachineService), typeof(FingerScanMachineService));
            #endregion

            #region UserService
            //FingerScanMachineService
            services.AddScoped(typeof(IUserService), typeof(UserService));
            #endregion

            #endregion

            #region Mapper Config
            var autoMapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMissingTypeMaps = true;

                #region Salary
                //cfg.CreateMap<SalaryLevel,SalarylvlBasic>();
                //cfg.CreateMap<SalarylvlBasic, SalaryLevel>();
                cfg.CreateMap<SalaryRule, SalaryRuleResponse>();
                cfg.CreateMap<SalaryRuleBasic, SalaryRule>();
                cfg.CreateMap<SalaryRuleGroupBasic, SalaryRuleGroup>();
                cfg.CreateMap<SalaryRuleGroup, SalaryRuleGroupBasic>();
                #endregion

                #region DayMode
                cfg.CreateMap<DayMode, DayModeBasic>();
                cfg.CreateMap<DayModeBasic, DayMode>();
                cfg.CreateMap<DayModeCreateRequest, DayMode>();
                #endregion

                #region Employee
                //cfg.CreateMap<EmployeeJobBasic, EmployeeJob>();
                //cfg.CreateMap<EmployeeJob, EmployeeJobBasic>();
                cfg.CreateMap<Employee, EmployeeBasic>();
                cfg.CreateMap<UserBasic, Employee>();
                cfg.CreateMap<EmployeeBasic, Employee>();
                cfg.CreateMap<EmployeeDetail, Employee>();
                cfg.CreateMap<Employee, EmployeeDetail>();
                cfg.CreateMap<EmployeeGroup, EmployeeGroupBasic>();
                cfg.CreateMap<EmployeeGroupBasic, EmployeeGroup>();
                #endregion

                #region PayrollPeriod
                cfg.CreateMap<PayrollPeriod, PayrollPeriodBasic>();
                cfg.CreateMap<PayrollPeriod, PayrollPeriodResponse>();
                cfg.CreateMap<PayrollPeriodBasic, PayrollPeriod>();
                #endregion

                #region TimeFrame
                cfg.CreateMap<TimeFrame, TimeFrameBasic>();
                cfg.CreateMap<TimeFrameBasic, TimeFrame>();
                cfg.CreateMap<TimeFrameRequestCreate, TimeFrame>();
                #endregion

                #region PaySlip
                cfg.CreateMap<PaySlipBasic, PaySlip>();
                cfg.CreateMap<PaySlip, PaySlipBasic>();
                #endregion

                #region PayrollDetail
                cfg.CreateMap<PayrollDetail, PayrollDetailBasic>();
                cfg.CreateMap<PayrollDetailBasic, PayrollDetail>();
                cfg.CreateMap<PayrollDetail, PayrollDetailResponse>();
                cfg.CreateMap<PayrollDetail, PayrollDetailCheckResponse>();
                cfg.CreateMap<PayrollDetailCategory, PayrollDetailCategoryBasic>();
                cfg.CreateMap<PayrollDetailCategoryBasic, PayrollDetailCategory>();
                #endregion

                #region PaySlipTemplate
                cfg.CreateMap<PaySlipTemplateBasic, PaySlipTemplate>();
                cfg.CreateMap<PaySlipTemplate, PaySlipTemplateBasic>();
                cfg.CreateMap<TemplateDetailMappingBasic, TemplateDetailMapping>();
                cfg.CreateMap<TemplateDetailMapping, TemplateDetailMappingBasic>();
                cfg.CreateMap<PaySlipTemplate, PaySlipTemplateDetailResponse>();
                #endregion

                #region TimeMode
                cfg.CreateMap<TimeModeRule, TimeModeBasic>();
                cfg.CreateMap<TimeModeBasic, TimeModeRule>();
                #endregion

                #region Attendance
                cfg.CreateMap<AttendanceBasic, Attendance>();
                cfg.CreateMap<Attendance, AttendanceBasic>();
                cfg.CreateMap<AttentdenceRequest, Attendance>();
                cfg.CreateMap<Attendance, AttentdenceRequest>();
                cfg.CreateMap<Attendance, AttendanceResponse>();
                cfg.CreateMap<Attendance, AttendanceStatusResponse>();
                #endregion

                #region ShiftRegister
                cfg.CreateMap<ShiftRegister, ShiftRegisterResponse>();
                cfg.CreateMap<ShiftRegister, ShiftRegisterBasic>();
                cfg.CreateMap<ShiftRegisterBasic, ShiftRegister>();
                #endregion

                #region CheckFinger
                cfg.CreateMap<CheckFinger, CheckFingerBasic>();
                cfg.CreateMap<CheckFingerBasic, CheckFinger>();
                #endregion

                #region FingerScanMachine
                cfg.CreateMap<FingerScanMachine, FingerScanMachineBasic>();
                cfg.CreateMap<FingerScanMachineBasic, FingerScanMachine>();

                #endregion

                #region old
                //cfg.CreateMap<ArtistViewModel, Artist>()
                //    .ForMember(x => x.Blogs, y => y.Ignore())
                //    .ForMember(x => x.Products, x => x.Ignore());
                //cfg.CreateMap<ProductCollectionViewModel, ProductCollections>()
                //    .ForMember(x => x.Products, y => y.Ignore())
                //    .ForMember(x => x.Artist, y => y.Ignore());
                //cfg.CreateMap<ProductCollections, ProductCollectionViewModel>()
                //    .ForMember(x => x.ListProducts, y => y.Ignore());
                //cfg.CreateMap<ProductViewModel, Products>()
                //    .ForMember(x => x.Artist, y => y.Ignore());
                //cfg.CreateMap<BlogViewModel, Blogs>()
                //    .ForMember(x => x.BlogCategory, y => y.Ignore())
                //    .ForMember(x => x.DraftTime, y => y.Condition(o=> o.DraftTime > DateTime.MinValue));
                #endregion
            });
            IMapper mapper = autoMapperConfig.CreateMapper();
            services.AddSingleton(mapper); 
            #endregion
        }


        private static void ConfigAutoMapper(IMapperConfigurationExpression config)
        {
            config.CreateMissingTypeMaps = true;
            config.AllowNullDestinationValues = false;
        }
    }
    

}
