using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VLS.Domain.Entities;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reference>()
                .HasMany(x => x.Locations)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.Country_ID)
                .HasPrincipalKey(x => x.Reference_ID);

            modelBuilder.Entity<Reference>()
                .HasMany(x => x.Locations)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.Country_ID)
                .HasPrincipalKey(x => x.Reference_ID);

            modelBuilder.Entity<Reference>()
                .HasMany(x => x.Locations)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.Country_ID)
                .HasPrincipalKey(x => x.Reference_ID);
                

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
