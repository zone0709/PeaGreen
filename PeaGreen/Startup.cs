using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DataCore.Models.Entities;
using DataCore.Models.Indentities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using DataCore;
using DataCore.Models.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SkyConnect.API.Identities;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Web.Http.Description;

namespace PeaGreen
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            RootConfig.Entry(services, Configuration);
            services.Configure<UserConfiguration>(Configuration.GetSection("UserConfiguration"));
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.Audience = "http://dev.authorize.reso.vn";
            //        options.ClaimsIssuer = "http://dev.authorize.reso.vn";
            //        options.Authority = "issuers";
            //    });
            //var DBConnect = this.Configuration.GetConnectionString("DBContext");
            //var IdentityConnect = this.Configuration.GetConnectionString("IdentityContext");
            //services.AddDbContext<ApplicationDbContext>(o =>
            //{
            //    o.UseSqlServer(IdentityConnect);
            //});

            // service context
            //services.AddDbContext<Pea_devContext>(o =>
            //{
            //    o.UseSqlServer(DBConnect);
            //});

            //add identity 
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(options =>
            {
                // add an instance of the filter, like we used to do it
                //options.Filters.Add(new BlockCustomAttribute());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Pea API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.DocumentFilter<ApplyDocumentVendorExtensions>();
                c.IncludeXmlComments(xmlPath);

            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Pea API V1");

                c.RoutePrefix = string.Empty;
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}



            app.UseHttpsRedirection();
            app.UseMvc();

            // create DB 
            //dbContext.Database.EnsureCreated();
        }
        //public class ApplyDocumentVendorExtensions : IDocumentFilter
        //{
        //    #region old
        //    //public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry s, IApiExplorer a)
        //    //{
        //    //    if (swaggerDoc != null)
        //    //    {
        //    //        foreach (var path in swaggerDoc.Paths)
        //    //        {
        //    //            if (path.Value.Get != null && path.Value.Get.Parameters != null)
        //    //            {

        //    //                var parameters = path.Value.Get.Parameters;
        //    //                foreach (var item in parameters)
        //    //                {
        //    //                    var index = item.Name.IndexOf(".");
        //    //                    item.Name = item.Name.Substring(index + 1);
        //    //                    //var list = item.name.Split('.');
        //    //                    //item.name = list[1];
        //    //                }
        //    //                //if (parameters.Count == 3 && parameters[0].name.StartsWith("emp"))
        //    //                //{
        //    //                //    path.Value.post.parameters = EmployeeBodyParam;
        //    //                //}
        //    //            }
        //    //            if (path.Value.Delete != null && path.Value.Delete.Parameters != null)
        //    //            {
        //    //                var parameters = path.Value.Delete.Parameters;

        //    //                foreach (var item in parameters)
        //    //                {
        //    //                    if (item.In.Contains("query"))
        //    //                    {

        //    //                        var index = item.Name.IndexOf(".");
        //    //                        if (index != -1)
        //    //                        {
        //    //                            item.Name = item.Name.Substring(index + 1);
        //    //                            item.Required = true;
        //    //                        }

        //    //                    }
        //    //                }
        //    //            }

        //    //        }
        //    //    }
        //    //}
        //    #endregion

        //    public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        //    {
        //        if (swaggerDoc != null)
        //        {
        //            foreach (var path in swaggerDoc.Paths)
        //            {
        //                if (path.Value.Get != null && path.Value.Get.Parameters != null)
        //                {

        //                    var parameters = path.Value.Get.Parameters;
        //                    foreach (var item in parameters)
        //                    {
        //                        var index = item.Name.IndexOf(".");
        //                        item.Name = item.Name.Substring(index + 1);
        //                        //var list = item.name.Split('.');
        //                        //item.name = list[1];
        //                    }
        //                    //if (parameters.Count == 3 && parameters[0].name.StartsWith("emp"))
        //                    //{
        //                    //    path.Value.post.parameters = EmployeeBodyParam;
        //                    //}
        //                }
        //                if (path.Value.Delete != null && path.Value.Delete.Parameters != null)
        //                {
        //                    var parameters = path.Value.Delete.Parameters;

        //                    foreach (var item in parameters)
        //                    {
        //                        if (item.In.Contains("query"))
        //                        {

        //                            var index = item.Name.IndexOf(".");
        //                            if (index != -1)
        //                            {
        //                                item.Name = item.Name.Substring(index + 1);
        //                                item.Required = true;
        //                            }

        //                        }
        //                    }
        //                }

        //            }
        //        }
        //    }
        //}
    }
}
