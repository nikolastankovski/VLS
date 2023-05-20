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
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
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
                .HasKey(x => x.ApplicationFileId);

            builder.Entity<City>()
                .HasKey(x => x.CityId);

            builder.Entity<City>()
                .HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId)
                .HasPrincipalKey(x => x.CountryId);

            builder.Entity<Company>()
                .HasKey(x => x.CompanyId);

            builder.Entity<Country>()
                    .HasKey(x => x.CountryId);

            builder.Entity<Country>()
                .Property(x => x.IsEUMember)
                .HasDefaultValue(false);

            builder.Entity<Course>()
                .HasKey(x => x.CourseId);

            builder.Entity<CourseVersion>()
                .HasKey(x => x.CourseVersionId);

            builder.Entity<CourseVersion>()
                .HasOne(x => x.Course)
                .WithMany(x => x.CourseVersions)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x => x.CourseId);

            builder.Entity<Employee>()
                .HasKey(x => x.EmployeeId);

            builder.Entity<Employee>()
                .HasOne(x => x.OrganizationalUnit)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.OrganizationalUnitCode)
                .HasPrincipalKey(x => x.Code);

            builder.Entity<Location>()
                .HasKey(x => x.LocationId);

            builder.Entity<Location>()
                .HasOne(x => x.Country)
                .WithMany(x => x.LocationCountries)
                .HasForeignKey(x => x.CountryId)
                .HasPrincipalKey(x => x.ReferenceId);

            builder.Entity<Location>()
                .HasOne(x => x.City)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CityId)
                .HasPrincipalKey(x => x.ReferenceId);

            builder.Entity<Location>()
                .HasOne(x => x.Municipality)
                .WithMany(x => x.Municipalities)
                .HasForeignKey(x => x.MunicipalityId)
                .HasPrincipalKey(x => x.ReferenceId);

            builder.Entity<OrganizationalUnit>()
                .HasKey(x => x.OrganizationalUnitId);

            builder.Entity<Reference>()
                .HasKey(x => x.ReferenceId);

            builder.Entity<Reference>()
                .HasOne(x => x.ReferenceType)
                .WithMany(x => x.References)
                .HasForeignKey(x => x.ReferenceTypeId)
                .HasPrincipalKey(x => x.ReferenceTypeId);

            builder.Entity<ReferenceType>()
                .HasKey(x => x.ReferenceTypeId);

            builder.Entity<TransactionVehicle>()
                .HasKey(x => x.TransactionVehicleId);

            builder.Entity<TransactionVehicle>()
                .HasOne(x => x.Location)
                .WithMany(x => x.TransactionVehicles)
                .HasForeignKey(x => x.LocationId)
                .HasPrincipalKey(x => x.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVehicle>()
                .HasOne(x => x.Vehicle)
                .WithMany(x => x.TransactionVehicles)
                .HasForeignKey(x => x.VehicleId)
                .HasPrincipalKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVehicle>()
                .HasOne(x => x.EntryVisitor)
                .WithMany(x => x.EntryVisitors)
                .HasForeignKey(x => x.EntryVisitorId)
                .HasPrincipalKey(x => x.VisitorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVehicle>()
                .HasOne(x => x.ExitVisitor)
                .WithMany(x => x.ExitVisitors)
                .HasForeignKey(x => x.ExitVisitorId)
                .HasPrincipalKey(x => x.VisitorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVisitor>()
                .HasKey(x => x.TransactionVisitorId);

            builder.Entity<TransactionVisitor>()
                .HasOne(x => x.Visitor)
                .WithMany(x => x.TransactionVisitors)
                .HasForeignKey(x => x.VisitorId)
                .HasPrincipalKey(x => x.VisitorId);

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
                .HasForeignKey(x => x.LocationId)
                .HasPrincipalKey(x => x.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TransactionVisitor>()
                .HasOne(x => x.Activity)
                .WithMany(x => x.TransactionVisitors)
                .HasForeignKey(x => x.ActivityId)
                .HasPrincipalKey(x => x.ReferenceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Vehicle>()
                .HasKey(x => x.VehicleId);

            builder.Entity<Vehicle>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.CompanyId)
                .HasPrincipalKey(x => x.CompanyId);

            builder.Entity<Visitor>()
                .HasKey(x => x.VisitorId);

            builder.Entity<Visitor>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Visitors)
                .HasForeignKey(x => x.CompanyId)
                .HasPrincipalKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Visitor>()
                .HasOne(x => x.Country)
                .WithMany(x => x.VisitorCountries)
                .HasForeignKey(x => x.CountryId)
                .HasPrincipalKey(x => x.ReferenceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Visitor>()
                .HasOne(x => x.IDType)
                .WithMany(x => x.IDTypes)
                .HasForeignKey(x => x.IDTypeId)
                .HasPrincipalKey(x => x.ReferenceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<VisitorCourse>()
                .HasKey(x => x.VisitorCourseId);

            builder.Entity<VisitorCourse>()
                .HasOne(x => x.Visitor)
                .WithMany(x => x.VisitorCourses)
                .HasForeignKey(x => x.VisitorId)
                .HasPrincipalKey(x => x.VisitorId);

            builder.Entity<VisitorCourse>()
                .HasOne(x => x.Course)
                .WithMany(x => x.VisitorCourses)
                .HasForeignKey(x => x.CourseId)
                .HasPrincipalKey(x => x.CourseId);

            builder.Entity<VisitorCourse>()
                .HasOne(x => x.Location)
                .WithMany(x => x.VisitorCourses)
                .HasForeignKey(x => x.LocationId)
                .HasPrincipalKey(x => x.LocationId);

            builder.Entity<VisitorCourse>()
                .HasOne(x => x.SignatureFile)
                .WithMany(x => x.VisitorCourses)
                .HasForeignKey(x => x.SignatureFileId)
                .HasPrincipalKey(x => x.ApplicationFileId);

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
