using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataCore.Models.Entities
{
    public partial class Pea_devContext : DbContext
    {
        public Pea_devContext()
        {
        }

        public Pea_devContext(DbContextOptions<Pea_devContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<AttendanceTmp> AttendanceTmp { get; set; }
        public virtual DbSet<DayType> DayType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAttribute> EmployeeAttribute { get; set; }
        public virtual DbSet<EmployeeAttributeMapping> EmployeeAttributeMapping { get; set; }
        public virtual DbSet<EmployeeGroup> EmployeeGroup { get; set; }
        public virtual DbSet<EmployeeGroupMapping> EmployeeGroupMapping { get; set; }
        public virtual DbSet<EmployeeJob> EmployeeJob { get; set; }
        public virtual DbSet<EmployeeJobMapping> EmployeeJobMapping { get; set; }
        public virtual DbSet<EmployeeWorkingShiftAutoMapping> EmployeeWorkingShiftAutoMapping { get; set; }
        public virtual DbSet<EmployeeWorkingShiftRegitser> EmployeeWorkingShiftRegitser { get; set; }
        public virtual DbSet<PaySlip> PaySlip { get; set; }
        public virtual DbSet<PaySlipAttribute> PaySlipAttribute { get; set; }
        public virtual DbSet<PaySlipAttributeMapping> PaySlipAttributeMapping { get; set; }
        public virtual DbSet<PaySlipItem> PaySlipItem { get; set; }
        public virtual DbSet<PaySlipItemAttributeMapping> PaySlipItemAttributeMapping { get; set; }
        public virtual DbSet<PaySlipItemAttrtibute> PaySlipItemAttrtibute { get; set; }
        public virtual DbSet<PaySlipTemplate> PaySlipTemplate { get; set; }
        public virtual DbSet<PaySlipTemplateMapping> PaySlipTemplateMapping { get; set; }
        public virtual DbSet<PayrollDetail> PayrollDetail { get; set; }
        public virtual DbSet<PayrollDetailCategory> PayrollDetailCategory { get; set; }
        public virtual DbSet<PayrollFormula> PayrollFormula { get; set; }
        public virtual DbSet<PayrollPeriod> PayrollPeriod { get; set; }
        public virtual DbSet<SalaryLevel> SalaryLevel { get; set; }
        public virtual DbSet<SalaryRule> SalaryRule { get; set; }
        public virtual DbSet<SalaryRuleGroup> SalaryRuleGroup { get; set; }
        public virtual DbSet<SalaryRuleGroupMapping> SalaryRuleGroupMapping { get; set; }
        public virtual DbSet<TimeMode> TimeMode { get; set; }
        public virtual DbSet<TimeSummary> TimeSummary { get; set; }
        public virtual DbSet<WorkType> WorkType { get; set; }
        public virtual DbSet<WorkingShift> WorkingShift { get; set; }
        public virtual DbSet<WorkingShiftAutoTmp> WorkingShiftAutoTmp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Pea_dev;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.UpdatePerson).HasMaxLength(150);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Attendance_Employee");
            });

            modelBuilder.Entity<AttendanceTmp>(entity =>
            {
                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AttendanceTmp)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttendanceTmp_Employee");
            });

            modelBuilder.Entity<DayType>(entity =>
            {
                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.DayTypeName).HasMaxLength(50);

                entity.Property(e => e.DaysOfTheWeek).HasMaxLength(50);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmployeeName).HasMaxLength(500);

                entity.Property(e => e.Phone).HasMaxLength(500);

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(50);

                entity.HasOne(d => d.SalaryLevel)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.SalaryLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_SalaryLevel");
            });

            modelBuilder.Entity<EmployeeAttribute>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeAttributeMapping>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeAttributeId).HasColumnName("EmployeeAttributeID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Quality).HasMaxLength(50);

                entity.HasOne(d => d.EmployeeAttribute)
                    .WithMany(p => p.EmployeeAttributeMapping)
                    .HasForeignKey(d => d.EmployeeAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeAttributeMapping_EmployeeAttribute");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeAttributeMapping)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeAttributeMapping_Employee");
            });

            modelBuilder.Entity<EmployeeGroup>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeGroupMapping>(entity =>
            {
                entity.HasOne(d => d.EmployeeGroup)
                    .WithMany(p => p.EmployeeGroupMapping)
                    .HasForeignKey(d => d.EmployeeGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeGroupMapping_EmployeeGroup");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeGroupMapping)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeGroupMapping_Employee");
            });

            modelBuilder.Entity<EmployeeJob>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(250);
            });

            modelBuilder.Entity<EmployeeJobMapping>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeJobMapping)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeRoleMapping_Employee");

                entity.HasOne(d => d.EmployeeRole)
                    .WithMany(p => p.EmployeeJobMapping)
                    .HasForeignKey(d => d.EmployeeRoleId)
                    .HasConstraintName("FK_EmployeeRoleMapping_EmployeeRole");
            });

            modelBuilder.Entity<EmployeeWorkingShiftAutoMapping>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeWorkingShiftAutoMapping)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeWorkingShiftAutoMapping_Employee");

                entity.HasOne(d => d.WorkingShiftAutoTmp)
                    .WithMany(p => p.EmployeeWorkingShiftAutoMapping)
                    .HasForeignKey(d => d.WorkingShiftAutoTmpId)
                    .HasConstraintName("FK_EmployeeWorkingShiftAutoMapping_WorkingShiftAutoTmp");
            });

            modelBuilder.Entity<EmployeeWorkingShiftRegitser>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.TimeCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeWorkingShiftRegitser)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeWorkingShiftRegitser_Employee");

                entity.HasOne(d => d.WorkingShift)
                    .WithMany(p => p.EmployeeWorkingShiftRegitser)
                    .HasForeignKey(d => d.WorkingShiftId)
                    .HasConstraintName("FK_EmployeeWorkingShiftRegitser_WorkingShift");
            });

            modelBuilder.Entity<PaySlip>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PaySlip)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlip_Employee");

                entity.HasOne(d => d.PayrollPeriod)
                    .WithMany(p => p.PaySlip)
                    .HasForeignKey(d => d.PayrollPeriodId)
                    .HasConstraintName("FK_PaySlip_PayrollPeriod");
            });

            modelBuilder.Entity<PaySlipAttribute>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PaySlipAttributeMapping>(entity =>
            {
                entity.Property(e => e.Quality).HasMaxLength(50);

                entity.HasOne(d => d.PaySlipAttribute)
                    .WithMany(p => p.PaySlipAttributeMapping)
                    .HasForeignKey(d => d.PaySlipAttributeId)
                    .HasConstraintName("FK_PaySlipAttributeMapping_PaySlipAttribute");

                entity.HasOne(d => d.PaySlip)
                    .WithMany(p => p.PaySlipAttributeMapping)
                    .HasForeignKey(d => d.PaySlipId)
                    .HasConstraintName("FK_PaySlipAttributeMapping_PaySlip");
            });

            modelBuilder.Entity<PaySlipItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaySlipId).HasColumnName("PaySlipID");

                entity.Property(e => e.PayrollDeatilId).HasColumnName("PayrollDeatilID");

                entity.HasOne(d => d.PaySlip)
                    .WithMany(p => p.PaySlipItem)
                    .HasForeignKey(d => d.PaySlipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlipItem_PaySlip");

                entity.HasOne(d => d.PayrollDeatil)
                    .WithMany(p => p.PaySlipItem)
                    .HasForeignKey(d => d.PayrollDeatilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlipItem_PayrollDetail");
            });

            modelBuilder.Entity<PaySlipItemAttributeMapping>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Quality).HasMaxLength(50);

                entity.HasOne(d => d.PaySlipItemAttribute)
                    .WithMany(p => p.PaySlipItemAttributeMapping)
                    .HasForeignKey(d => d.PaySlipItemAttributeId)
                    .HasConstraintName("FK_PaySlipItemAttributeMapping_PaySlipItemAttrtibute");

                entity.HasOne(d => d.PaySlipItem)
                    .WithMany(p => p.PaySlipItemAttributeMapping)
                    .HasForeignKey(d => d.PaySlipItemId)
                    .HasConstraintName("FK_PaySlipItemAttributeMapping_PaySlipItem");
            });

            modelBuilder.Entity<PaySlipItemAttrtibute>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PaySlipTemplate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PaySlipTemplateMapping>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PaySlipTemplateId).HasColumnName("PaySlipTemplateID");

                entity.Property(e => e.PayrollDetailId).HasColumnName("PayrollDetailID");

                entity.HasOne(d => d.PaySlipTemplate)
                    .WithMany(p => p.PaySlipTemplateMapping)
                    .HasForeignKey(d => d.PaySlipTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlipTemplateMapping_PaySlipTemplate");

                entity.HasOne(d => d.PayrollDetail)
                    .WithMany(p => p.PaySlipTemplateMapping)
                    .HasForeignKey(d => d.PayrollDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlipTemplateMapping_PayrollDetail");
            });

            modelBuilder.Entity<PayrollDetail>(entity =>
            {
                entity.Property(e => e.DefaultFormulaId).HasColumnName("DefaultFormulaID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Destination).HasMaxLength(50);

                entity.Property(e => e.Frequency).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PayrollDetailCategoryId).HasColumnName("PayrollDetailCategoryID");

                entity.Property(e => e.SalaryRuleGroupId).HasColumnName("SalaryRuleGroupID");

                entity.Property(e => e.Variability).HasMaxLength(50);

                entity.HasOne(d => d.PayrollDetailCategory)
                    .WithMany(p => p.PayrollDetail)
                    .HasForeignKey(d => d.PayrollDetailCategoryId)
                    .HasConstraintName("FK_PayrollDetail_PayrollDetailCategory");

                entity.HasOne(d => d.SalaryRuleGroup)
                    .WithMany(p => p.PayrollDetail)
                    .HasForeignKey(d => d.SalaryRuleGroupId)
                    .HasConstraintName("FK_PayrollDetail_SalaryRuleGroup");
            });

            modelBuilder.Entity<PayrollDetailCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PayrollFormula>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Expression)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PayrollDetailId).HasColumnName("PayrollDetailID");

                entity.HasOne(d => d.PayrollDetail)
                    .WithMany(p => p.PayrollFormula)
                    .HasForeignKey(d => d.PayrollDetailId)
                    .HasConstraintName("FK_PayrollFormula_PayrollDetail");
            });

            modelBuilder.Entity<PayrollPeriod>(entity =>
            {
                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.PaySlipTemplate)
                    .WithMany(p => p.PayrollPeriod)
                    .HasForeignKey(d => d.PaySlipTemplateId)
                    .HasConstraintName("FK_PayrollPeriod_PaySlipTemplate");
            });

            modelBuilder.Entity<SalaryLevel>(entity =>
            {
                entity.Property(e => e.SalaryLevelName).HasMaxLength(50);
            });

            modelBuilder.Entity<SalaryRule>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SalaryRuleGroup>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SalaryRuleGroupMapping>(entity =>
            {
                entity.HasOne(d => d.SalaryRuleGroup)
                    .WithMany(p => p.SalaryRuleGroupMapping)
                    .HasForeignKey(d => d.SalaryRuleGroupId)
                    .HasConstraintName("FK_SalaryRuleGroupMapping_SalaryRuleGroup");

                entity.HasOne(d => d.SalaryRule)
                    .WithMany(p => p.SalaryRuleGroupMapping)
                    .HasForeignKey(d => d.SalaryRuleId)
                    .HasConstraintName("FK_SalaryRuleGroupMapping_SalaryRule");
            });

            modelBuilder.Entity<TimeMode>(entity =>
            {
                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.TimeModeName).HasMaxLength(50);

                entity.HasOne(d => d.DayType)
                    .WithMany(p => p.TimeMode)
                    .HasForeignKey(d => d.DayTypeId)
                    .HasConstraintName("FK_TimeMode_DayType");
            });

            modelBuilder.Entity<TimeSummary>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.UpdatedPerson).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TimeSummary)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_TimeSummary_Employee");

                entity.HasOne(d => d.TimeMode)
                    .WithMany(p => p.TimeSummary)
                    .HasForeignKey(d => d.TimeModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeSummary_TimeMode");
            });

            modelBuilder.Entity<WorkType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FromTime).HasColumnType("datetime");

                entity.Property(e => e.ToTime).HasColumnType("datetime");

                entity.Property(e => e.WorkTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkingShift>(entity =>
            {
                entity.Property(e => e.WorkingShiftName).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkingShiftAutoTmp>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
