using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models.Indentities
{
    //public class ApplicationUser : IdentityUser
    //{
    //    public int? BrandId { get; set; }
    //    public string FullName { get; set; }
    //    public int? CustomerId { get; set; }
    //    public int? EmployeeId { get; set; }
    //    public int? AdminStoreId { get; set; }
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
    //        userIdentity.AddClaim(new Claim("CustomerId", this.CustomerId.ToString()));
    //        // Add custom user claims here
    //        userIdentity.AddClaim(new Claim("EmployeeId", this.EmployeeId.ToString()));
    //        userIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, this.Id));

    //        return userIdentity;
    //    }
    //}

    public class ApplicationDbContext : IdentityDbContext/*<ApplicationUser>*/
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public ApplicationDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DBContext"));
        //}
        ////public ApplicationDbContext()
        ////    : base("DefaultConnection",)
        ////{
        ////}

        //public static ApplicationDbContext Create(IConfiguration configuration)
        //{
        //    return new ApplicationDbContext(configuration);
        //}
        //private static string GetConnectionString()
        //{
        //    const string databaseName = "Pea_dev";
        //    const string databaseUser = "sa";
        //    const string databasePass = "";

        //    return $"Server=localhost;" +
        //           $"database={databaseName};" +
        //           $"uid={databaseUser};" +
        //           $"pwd={databasePass};" +
        //           $"pooling=true;";
        //}

    }
}
