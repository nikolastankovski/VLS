using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationFiles",
                columns: table => new
                {
                    ApplicationFile_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFiles", x => x.ApplicationFile_ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Company_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Company_ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_ID);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalUnits",
                columns: table => new
                {
                    OrganizationalUnit_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalUnits", x => x.OrganizationalUnit_ID);
                    table.UniqueConstraint("AK_OrganizationalUnits_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceTypes",
                columns: table => new
                {
                    ReferenceType_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceTypes", x => x.ReferenceType_ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Vehicle_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_ID = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TechnicalCorrectnessExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Vehicle_ID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Companies_Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Companies",
                        principalColumn: "Company_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseVersions",
                columns: table => new
                {
                    CourseVersion_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidityPeriodInMonths = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseVersions", x => x.CourseVersion_ID);
                    table.ForeignKey(
                        name: "FK_CourseVersions_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrganizationalUnitCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_ID);
                    table.UniqueConstraint("AK_Employees_Code", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Employees_OrganizationalUnits_OrganizationalUnitCode",
                        column: x => x.OrganizationalUnitCode,
                        principalTable: "OrganizationalUnits",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    Reference_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceType_ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Reference_ID);
                    table.ForeignKey(
                        name: "FK_References_ReferenceTypes_ReferenceType_ID",
                        column: x => x.ReferenceType_ID,
                        principalTable: "ReferenceTypes",
                        principalColumn: "ReferenceType_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Country_ID = table.Column<int>(type: "int", nullable: false),
                    City_ID = table.Column<int>(type: "int", nullable: true),
                    Municipality_ID = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location_ID);
                    table.ForeignKey(
                        name: "FK_Locations_References_City_ID",
                        column: x => x.City_ID,
                        principalTable: "References",
                        principalColumn: "Reference_ID");
                    table.ForeignKey(
                        name: "FK_Locations_References_Country_ID",
                        column: x => x.Country_ID,
                        principalTable: "References",
                        principalColumn: "Reference_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_References_Municipality_ID",
                        column: x => x.Municipality_ID,
                        principalTable: "References",
                        principalColumn: "Reference_ID");
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Visitor_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IDType_ID = table.Column<int>(type: "int", nullable: false),
                    IDNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country_ID = table.Column<int>(type: "int", nullable: false),
                    Company_ID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Visitor_ID);
                    table.ForeignKey(
                        name: "FK_Visitors_Companies_Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Companies",
                        principalColumn: "Company_ID");
                    table.ForeignKey(
                        name: "FK_Visitors_References_Country_ID",
                        column: x => x.Country_ID,
                        principalTable: "References",
                        principalColumn: "Reference_ID");
                    table.ForeignKey(
                        name: "FK_Visitors_References_IDType_ID",
                        column: x => x.IDType_ID,
                        principalTable: "References",
                        principalColumn: "Reference_ID");
                });

            migrationBuilder.CreateTable(
                name: "TransactionVisitors",
                columns: table => new
                {
                    TransactionVisitor_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visitor_ID = table.Column<long>(type: "bigint", nullable: false),
                    VehicleRegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VisiteeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrganizationUnitCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location_ID = table.Column<int>(type: "int", nullable: false),
                    SpecificPlace = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EntryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activity_ID = table.Column<int>(type: "int", nullable: false),
                    Incident = table.Column<bool>(type: "bit", nullable: false),
                    IncidentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionVisitors", x => x.TransactionVisitor_ID);
                    table.ForeignKey(
                        name: "FK_TransactionVisitors_Employees_VisiteeCode",
                        column: x => x.VisiteeCode,
                        principalTable: "Employees",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_TransactionVisitors_Locations_Location_ID",
                        column: x => x.Location_ID,
                        principalTable: "Locations",
                        principalColumn: "Location_ID");
                    table.ForeignKey(
                        name: "FK_TransactionVisitors_OrganizationalUnits_OrganizationUnitCode",
                        column: x => x.OrganizationUnitCode,
                        principalTable: "OrganizationalUnits",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_TransactionVisitors_References_Activity_ID",
                        column: x => x.Activity_ID,
                        principalTable: "References",
                        principalColumn: "Reference_ID");
                    table.ForeignKey(
                        name: "FK_TransactionVisitors_Visitors_Visitor_ID",
                        column: x => x.Visitor_ID,
                        principalTable: "Visitors",
                        principalColumn: "Visitor_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitorCourses",
                columns: table => new
                {
                    VisitorCourse_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visitor_ID = table.Column<long>(type: "bigint", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Location_ID = table.Column<int>(type: "int", nullable: false),
                    DateCourseTaken = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SignatureFile_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorCourses", x => x.VisitorCourse_ID);
                    table.ForeignKey(
                        name: "FK_VisitorCourses_ApplicationFiles_SignatureFile_ID",
                        column: x => x.SignatureFile_ID,
                        principalTable: "ApplicationFiles",
                        principalColumn: "ApplicationFile_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorCourses_Courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorCourses_Locations_Location_ID",
                        column: x => x.Location_ID,
                        principalTable: "Locations",
                        principalColumn: "Location_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorCourses_Visitors_Visitor_ID",
                        column: x => x.Visitor_ID,
                        principalTable: "Visitors",
                        principalColumn: "Visitor_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseVersions_Course_ID",
                table: "CourseVersions",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OrganizationalUnitCode",
                table: "Employees",
                column: "OrganizationalUnitCode");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_City_ID",
                table: "Locations",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Country_ID",
                table: "Locations",
                column: "Country_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Municipality_ID",
                table: "Locations",
                column: "Municipality_ID");

            migrationBuilder.CreateIndex(
                name: "IX_References_ReferenceType_ID",
                table: "References",
                column: "ReferenceType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionVisitors_Activity_ID",
                table: "TransactionVisitors",
                column: "Activity_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionVisitors_Location_ID",
                table: "TransactionVisitors",
                column: "Location_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionVisitors_OrganizationUnitCode",
                table: "TransactionVisitors",
                column: "OrganizationUnitCode");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionVisitors_VisiteeCode",
                table: "TransactionVisitors",
                column: "VisiteeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionVisitors_Visitor_ID",
                table: "TransactionVisitors",
                column: "Visitor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Company_ID",
                table: "Vehicles",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorCourses_Course_ID",
                table: "VisitorCourses",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorCourses_Location_ID",
                table: "VisitorCourses",
                column: "Location_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorCourses_SignatureFile_ID",
                table: "VisitorCourses",
                column: "SignatureFile_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorCourses_Visitor_ID",
                table: "VisitorCourses",
                column: "Visitor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_Company_ID",
                table: "Visitors",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_Country_ID",
                table: "Visitors",
                column: "Country_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_IDType_ID",
                table: "Visitors",
                column: "IDType_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseVersions");

            migrationBuilder.DropTable(
                name: "TransactionVisitors");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VisitorCourses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ApplicationFiles");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "OrganizationalUnits");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "ReferenceTypes");
        }
    }
}
