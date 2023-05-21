using Microsoft.EntityFrameworkCore;
using VLS.Infrastructure.Repositories;
using VLS.Shared;
using VLS.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VLSDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(Helper.GetAutoMapperProfilesFromAllAssemblies().ToArray());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region REPOSITORIES
    builder.Services.AddScoped<ICityRepository, CityRepository>();
    builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
    builder.Services.AddScoped<ICountryRepository, CountryRepository>();
    builder.Services.AddScoped<ICourseRepository, CourseRepository>();
    builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    builder.Services.AddScoped<ILocationRepository, LocationRepository>();
    builder.Services.AddScoped<IOrganizationalUnitRepository, OrganizationalUnitRepository>();
    builder.Services.AddScoped<IReferenceRepository, ReferenceRepository>();
    builder.Services.AddScoped<IReferenceTypeRepository, ReferenceTypeRepository>();
    builder.Services.AddScoped<ITransactionVehicleRepository, TransactionVehicleRepository>();
    builder.Services.AddScoped<ITransactionVisitorRepository, TransactionVisitorRepository>();
    builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
    builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
#endregion

#region SERVICES
    builder.Services.AddScoped<CompanyService>();
    builder.Services.AddScoped<CourseService>();
    builder.Services.AddScoped<EmployeeService>();
    builder.Services.AddScoped<LocationService>();
    builder.Services.AddScoped<OrganizationalUnitService>();
    builder.Services.AddScoped<ReferenceService>();
    builder.Services.AddScoped<ReferenceTypeService>();
    builder.Services.AddScoped<TransactionVehicleService>();
    builder.Services.AddScoped<TransactionVisitorService>();
    builder.Services.AddScoped<VehicleService>();
    builder.Services.AddScoped<VisitorService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
