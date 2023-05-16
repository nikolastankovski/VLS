using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace VLS.Infrastructure.Data
{
    public partial class VLSDbContext : DbContext
    {
        public VLSDbContext() { }
        public VLSDbContext(DbContextOptions<VLSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationFile> ApplicationFiles { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseVersion> CourseVersions { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<OrganizationalUnit> OrganizationalUnits { get; set; } = null!;
        public virtual DbSet<Reference> References { get; set; } = null!;
        public virtual DbSet<ReferenceType> ReferenceTypes { get; set; } = null!;
        public virtual DbSet<TransactionVehicle> TransactionVehicles { get; set; } = null!;
        public virtual DbSet<TransactionVisitor> TransactionVisitors { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<Visitor> Visitors { get; set; } = null!;
        public virtual DbSet<VisitorCourse> VisitorCourses { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Get connection string from appsettings.json
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationFile>()
                .HasKey(x => x.ApplicationFile_ID);

            builder.Entity<Company>()
                .HasKey(x => x.Company_ID);

            builder.Entity<Course>()
                .HasKey(x => x.Course_ID);

            builder.Entity<CourseVersion>()
                .HasKey(x => x.CourseVersion_ID);

            builder.Entity<CourseVersion>()
                .HasOne(x => x.Course)
                .WithMany(x => x.CourseVersions)
                .HasForeignKey(x => x.Course_ID)
                .HasPrincipalKey(x => x.Course_ID);

            builder.Entity<Employee>()
                .HasKey(x => x.Employee_ID);

            builder.Entity<Employee>()
                .HasOne(x => x.OrganizationalUnit)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.OrganizationalUnitCode)
                .HasPrincipalKey(x => x.Code);

            builder.Entity<Location>()
                .HasKey(x => x.Location_ID);

            builder.Entity<Location>()
                .HasOne(x => x.Country)
                .WithMany(x => x.LocationCountries)
                .HasForeignKey(x => x.Country_ID)
                .HasPrincipalKey(x => x.Reference_ID);

            builder.Entity<Location>()
                .HasOne(x => x.City)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.City_ID)
                .HasPrincipalKey(x => x.Reference_ID);

            builder.Entity<Location>()
                .HasOne(x => x.Municipality)
                .WithMany(x => x.Municipalities)
                .HasForeignKey(x => x.Municipality_ID)
                .HasPrincipalKey(x => x.Reference_ID);

            builder.Entity<OrganizationalUnit>()
                .HasKey(x => x.OrganizationalUnit_ID);

            builder.Entity<Reference>()
                .HasKey(x => x.Reference_ID);

            builder.Entity<Reference>()
                .HasOne(x => x.ReferenceType)
                .WithMany(x => x.References)
                .HasForeignKey(x => x.ReferenceType_ID)
                .HasPrincipalKey(x => x.ReferenceType_ID);

            builder.Entity<ReferenceType>()
                .HasKey(x => x.ReferenceType_ID);

            builder.Entity<TransactionVehicle>()
                .HasKey(x => x.TransactionVehicle_ID);

            builder.Entity<TransactionVehicle>()
                .HasOne(x => x.Location)
                .WithMany(x => x.TransactionVehicles)
                .HasForeignKey(x => x.Location_ID)
                .HasPrincipalKey(x => x.Location_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVehicle>()
                .HasOne(x => x.Vehicle)
                .WithMany(x => x.TransactionVehicles)
                .HasForeignKey(x => x.Vehicle_ID)
                .HasPrincipalKey(x => x.Vehicle_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVehicle>()
                .HasOne(x => x.EntryVisitor)
                .WithMany(x => x.EntryVisitors)
                .HasForeignKey(x => x.EntryVisitor_ID)
                .HasPrincipalKey(x => x.Visitor_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVehicle>()
                .HasOne(x => x.ExitVisitor)
                .WithMany(x => x.ExitVisitors)
                .HasForeignKey(x => x.ExitVisitor_ID)
                .HasPrincipalKey(x => x.Visitor_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVisitor>()
                .HasKey(x => x.TransactionVisitor_ID);

            builder.Entity<TransactionVisitor>()
                .HasOne(x => x.Visitor)
                .WithMany(x => x.TransactionVisitors)
                .HasForeignKey(x => x.Visitor_ID)
                .HasPrincipalKey(x => x.Visitor_ID);

            builder.Entity<TransactionVisitor>()
                .HasOne(x => x.Visitee)
                .WithMany(x => x.TransactionVisitors)
                .HasForeignKey(x => x.VisiteeCode)
                .HasPrincipalKey(x => x.Code)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVisitor>()
                .HasOne(x => x.OrganizationalUnit)
                .WithMany(x => x.TransactionVisitors)
                .HasForeignKey(x => x.OrganizationUnitCode)
                .HasPrincipalKey(x => x.Code)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVisitor>()
                .HasOne(x => x.Location)
                .WithMany(x => x.TransactionVisitors)
                .HasForeignKey(x => x.Location_ID)
                .HasPrincipalKey(x => x.Location_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVisitor>()
                .HasOne(x => x.Activity)
                .WithMany(x => x.TransactionVisitors)
                .HasForeignKey(x => x.Activity_ID)
                .HasPrincipalKey(x => x.Reference_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Vehicle>()
                .HasKey(x => x.Vehicle_ID);

            builder.Entity<Vehicle>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.Company_ID)
                .HasPrincipalKey(x => x.Company_ID);

            builder.Entity<Visitor>()
                .HasKey(x => x.Visitor_ID);

            builder.Entity<Visitor>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Visitors)
                .HasForeignKey(x => x.Company_ID)
                .HasPrincipalKey(x => x.Company_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Visitor>()
                .HasOne(x => x.Country)
                .WithMany(x => x.VisitorCountries)
                .HasForeignKey(x => x.Country_ID)
                .HasPrincipalKey(x => x.Reference_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Visitor>()
                .HasOne(x => x.IDType)
                .WithMany(x => x.IDTypes)
                .HasForeignKey(x => x.IDType_ID)
                .HasPrincipalKey(x => x.Reference_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<VisitorCourse>()
                .HasKey(x => x.VisitorCourse_ID);

            builder.Entity<VisitorCourse>()
                .HasOne(x => x.Visitor)
                .WithMany(x => x.VisitorCourses)
                .HasForeignKey(x => x.Visitor_ID)
                .HasPrincipalKey(x => x.Visitor_ID);

            builder.Entity<VisitorCourse>()
                .HasOne(x => x.Course)
                .WithMany(x => x.VisitorCourses)
                .HasForeignKey(x => x.Course_ID)
                .HasPrincipalKey(x => x.Course_ID);

            builder.Entity<VisitorCourse>()
                .HasOne(x => x.Location)
                .WithMany(x => x.VisitorCourses)
                .HasForeignKey(x => x.Location_ID)
                .HasPrincipalKey(x => x.Location_ID);

            builder.Entity<VisitorCourse>()
                .HasOne(x => x.SignatureFile)
                .WithMany(x => x.VisitorCourses)
                .HasForeignKey(x => x.SignatureFile_ID)
                .HasPrincipalKey(x => x.ApplicationFile_ID);

            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>()
                .HaveColumnType("date");
        }
        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// </summary>
            public DateOnlyConverter() : base(
                    d => d.ToDateTime(TimeOnly.MinValue),
                    d => DateOnly.FromDateTime(d))
            { }
        }

        /// <summary>
        /// Converts <see cref="DateOnly?" /> to <see cref="DateTime?"/> and vice versa.
        /// </summary>
        public class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// </summary>
            public NullableDateOnlyConverter() : base(
                d => d == null
                    ? null
                    : new DateTime?(d.Value.ToDateTime(TimeOnly.MinValue)),
                d => d == null
                    ? null
                    : new DateOnly?(DateOnly.FromDateTime(d.Value)))
            { }
        }
    }
}
