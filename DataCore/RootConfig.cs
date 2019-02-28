
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
            services.AddDbContext<Pea_devContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DBContext")));

            //// Config identity db config
            //services.AddDbContext<IdentityFandomContext>(options =>
            //                options.UseSqlServer(configuration.GetConnectionString("Doitsu.Identity.DBConStr")));

            //services.AddIdentity<DoitsuUserInt, IdentityRole<int>>()
            //    .AddEntityFrameworkStores<IdentityFandomContext>()
            //    .AddDefaultTokenProviders();

            services.AddScoped(typeof(DbContext), typeof(Pea_devContext));
            //services.AddScoped(typeof(IdentityDbContext<DoitsuUserInt, IdentityRole<int>, int>), typeof(IdentityFandomContext));
            //services.AddScoped(typeof(UserManager<DoitsuUserInt>), typeof(DoitsuUserIntManager));
            services.AddScoped(typeof(DoitsuUserIntManager));
            //services.AddScoped(typeof(UserManager<IdentityUser<int>>), typeof(DoitsuUserIntManager));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            DoitsuJWTServiceBuilder.BuildJWTService(services);
            #endregion

            #region DI Config
            services.AddScoped(typeof(ISalarylvlService), typeof(SalarylvlService));
            services.AddScoped(typeof(IDayTypeService), typeof(DayTypeService));
            services.AddScoped(typeof(IEmployeeJobService), typeof(EmployeeJobService));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
            services.AddScoped(typeof(IEmployeeJobMappingService), typeof(EmployeeJobMappingService));
            services.AddScoped(typeof(IEmployeeDetailService), typeof(EmployeeDetailService));
            services.AddScoped(typeof(IPayrollPeriodService), typeof(PayrollPeriodService));
            services.AddScoped(typeof(IPaySlipService), typeof(PaySlipService));
            services.AddScoped(typeof(IEmployeeGroupMappingService), typeof(EmployeeGroupMappingService));
            #endregion

            #region Mapper Config
            var autoMapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<SalaryLevel,SalarylvlBasic>();
                cfg.CreateMap<SalarylvlBasic, SalaryLevel>();
                cfg.CreateMap<DayType, DayTypeBasic>();
                cfg.CreateMap<DayTypeBasic, DayType>();
                cfg.CreateMap<EmployeeJobBasic, EmployeeJob>();
                cfg.CreateMap<EmployeeJob, EmployeeJobBasic>();
                cfg.CreateMap<Employee, EmployeeBasic>();
                cfg.CreateMap<EmployeeBasic, Employee>();
                cfg.CreateMap<EmployeeDetail, Employee>();
                cfg.CreateMap<Employee, EmployeeDetail>();
                cfg.CreateMap<PayrollPeriod, PayrollPeriodViewModel>();
                cfg.CreateMap<PayrollPeriodViewModel, PayrollPeriod>();
                cfg.CreateMap<PaySlipBasic, PaySlip>();
                cfg.CreateMap<PaySlip, PaySlipBasic>();
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
