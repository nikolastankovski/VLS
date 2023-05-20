using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLS.Infrastructure.Migrations
{
    public partial class RenameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_Country_ID",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseVersions_Courses_Course_ID",
                table: "CourseVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_References_City_ID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_References_Country_ID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_References_Municipality_ID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_References_ReferenceTypes_ReferenceType_ID",
                table: "References");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVehicles_Locations_Location_ID",
                table: "TransactionVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVehicles_Vehicles_Vehicle_ID",
                table: "TransactionVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVehicles_Visitors_EntryVisitor_ID",
                table: "TransactionVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVehicles_Visitors_ExitVisitor_ID",
                table: "TransactionVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVisitors_Locations_Location_ID",
                table: "TransactionVisitors");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVisitors_References_Activity_ID",
                table: "TransactionVisitors");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVisitors_Visitors_Visitor_ID",
                table: "TransactionVisitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companies_Company_ID",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorCourses_ApplicationFiles_SignatureFile_ID",
                table: "VisitorCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorCourses_Courses_Course_ID",
                table: "VisitorCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorCourses_Locations_Location_ID",
                table: "VisitorCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorCourses_Visitors_Visitor_ID",
                table: "VisitorCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Companies_Company_ID",
                table: "Visitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_References_Country_ID",
                table: "Visitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_References_IDType_ID",
                table: "Visitors");

            migrationBuilder.RenameColumn(
                name: "IDType_ID",
                table: "Visitors",
                newName: "IDTypeId");

            migrationBuilder.RenameColumn(
                name: "Country_ID",
                table: "Visitors",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Company_ID",
                table: "Visitors",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Visitor_ID",
                table: "Visitors",
                newName: "VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_IDType_ID",
                table: "Visitors",
                newName: "IX_Visitors_IDTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_Country_ID",
                table: "Visitors",
                newName: "IX_Visitors_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_Company_ID",
                table: "Visitors",
                newName: "IX_Visitors_CompanyId");

            migrationBuilder.RenameColumn(
                name: "Visitor_ID",
                table: "VisitorCourses",
                newName: "VisitorId");

            migrationBuilder.RenameColumn(
                name: "SignatureFile_ID",
                table: "VisitorCourses",
                newName: "SignatureFileId");

            migrationBuilder.RenameColumn(
                name: "Location_ID",
                table: "VisitorCourses",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "Course_ID",
                table: "VisitorCourses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "VisitorCourse_ID",
                table: "VisitorCourses",
                newName: "VisitorCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitorCourses_Visitor_ID",
                table: "VisitorCourses",
                newName: "IX_VisitorCourses_VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitorCourses_SignatureFile_ID",
                table: "VisitorCourses",
                newName: "IX_VisitorCourses_SignatureFileId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitorCourses_Location_ID",
                table: "VisitorCourses",
                newName: "IX_VisitorCourses_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitorCourses_Course_ID",
                table: "VisitorCourses",
                newName: "IX_VisitorCourses_CourseId");

            migrationBuilder.RenameColumn(
                name: "Company_ID",
                table: "Vehicles",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Vehicle_ID",
                table: "Vehicles",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_Company_ID",
                table: "Vehicles",
                newName: "IX_Vehicles_CompanyId");

            migrationBuilder.RenameColumn(
                name: "Visitor_ID",
                table: "TransactionVisitors",
                newName: "VisitorId");

            migrationBuilder.RenameColumn(
                name: "Location_ID",
                table: "TransactionVisitors",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "Activity_ID",
                table: "TransactionVisitors",
                newName: "ActivityId");

            migrationBuilder.RenameColumn(
                name: "TransactionVisitor_ID",
                table: "TransactionVisitors",
                newName: "TransactionVisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVisitors_Visitor_ID",
                table: "TransactionVisitors",
                newName: "IX_TransactionVisitors_VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVisitors_Location_ID",
                table: "TransactionVisitors",
                newName: "IX_TransactionVisitors_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVisitors_Activity_ID",
                table: "TransactionVisitors",
                newName: "IX_TransactionVisitors_ActivityId");

            migrationBuilder.RenameColumn(
                name: "Vehicle_ID",
                table: "TransactionVehicles",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "Location_ID",
                table: "TransactionVehicles",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "ExitVisitor_ID",
                table: "TransactionVehicles",
                newName: "ExitVisitorId");

            migrationBuilder.RenameColumn(
                name: "EntryVisitor_ID",
                table: "TransactionVehicles",
                newName: "EntryVisitorId");

            migrationBuilder.RenameColumn(
                name: "TransactionVehicle_ID",
                table: "TransactionVehicles",
                newName: "TransactionVehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVehicles_Vehicle_ID",
                table: "TransactionVehicles",
                newName: "IX_TransactionVehicles_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVehicles_Location_ID",
                table: "TransactionVehicles",
                newName: "IX_TransactionVehicles_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVehicles_ExitVisitor_ID",
                table: "TransactionVehicles",
                newName: "IX_TransactionVehicles_ExitVisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVehicles_EntryVisitor_ID",
                table: "TransactionVehicles",
                newName: "IX_TransactionVehicles_EntryVisitorId");

            migrationBuilder.RenameColumn(
                name: "ReferenceType_ID",
                table: "ReferenceTypes",
                newName: "ReferenceTypeId");

            migrationBuilder.RenameColumn(
                name: "ReferenceType_ID",
                table: "References",
                newName: "ReferenceTypeId");

            migrationBuilder.RenameColumn(
                name: "Reference_ID",
                table: "References",
                newName: "ReferenceId");

            migrationBuilder.RenameIndex(
                name: "IX_References_ReferenceType_ID",
                table: "References",
                newName: "IX_References_ReferenceTypeId");

            migrationBuilder.RenameColumn(
                name: "OrganizationalUnit_ID",
                table: "OrganizationalUnits",
                newName: "OrganizationalUnitId");

            migrationBuilder.RenameColumn(
                name: "Municipality_ID",
                table: "Locations",
                newName: "MunicipalityId");

            migrationBuilder.RenameColumn(
                name: "Country_ID",
                table: "Locations",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "City_ID",
                table: "Locations",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "Location_ID",
                table: "Locations",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_Municipality_ID",
                table: "Locations",
                newName: "IX_Locations_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_Country_ID",
                table: "Locations",
                newName: "IX_Locations_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_City_ID",
                table: "Locations",
                newName: "IX_Locations_CityId");

            migrationBuilder.RenameColumn(
                name: "Employee_ID",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Course_ID",
                table: "CourseVersions",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "CourseVersion_ID",
                table: "CourseVersions",
                newName: "CourseVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseVersions_Course_ID",
                table: "CourseVersions",
                newName: "IX_CourseVersions_CourseId");

            migrationBuilder.RenameColumn(
                name: "Course_ID",
                table: "Courses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "Country_ID",
                table: "Countries",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Company_ID",
                table: "Companies",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Country_ID",
                table: "Cities",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "City_ID",
                table: "Cities",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Country_ID",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.RenameColumn(
                name: "ApplicationFile_ID",
                table: "ApplicationFiles",
                newName: "ApplicationFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVersions_Courses_CourseId",
                table: "CourseVersions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_References_CityId",
                table: "Locations",
                column: "CityId",
                principalTable: "References",
                principalColumn: "ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_References_CountryId",
                table: "Locations",
                column: "CountryId",
                principalTable: "References",
                principalColumn: "ReferenceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_References_MunicipalityId",
                table: "Locations",
                column: "MunicipalityId",
                principalTable: "References",
                principalColumn: "ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_References_ReferenceTypes_ReferenceTypeId",
                table: "References",
                column: "ReferenceTypeId",
                principalTable: "ReferenceTypes",
                principalColumn: "ReferenceTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVehicles_Locations_LocationId",
                table: "TransactionVehicles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVehicles_Vehicles_VehicleId",
                table: "TransactionVehicles",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVehicles_Visitors_EntryVisitorId",
                table: "TransactionVehicles",
                column: "EntryVisitorId",
                principalTable: "Visitors",
                principalColumn: "VisitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVehicles_Visitors_ExitVisitorId",
                table: "TransactionVehicles",
                column: "ExitVisitorId",
                principalTable: "Visitors",
                principalColumn: "VisitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVisitors_Locations_LocationId",
                table: "TransactionVisitors",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVisitors_References_ActivityId",
                table: "TransactionVisitors",
                column: "ActivityId",
                principalTable: "References",
                principalColumn: "ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVisitors_Visitors_VisitorId",
                table: "TransactionVisitors",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "VisitorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companies_CompanyId",
                table: "Vehicles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorCourses_ApplicationFiles_SignatureFileId",
                table: "VisitorCourses",
                column: "SignatureFileId",
                principalTable: "ApplicationFiles",
                principalColumn: "ApplicationFileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorCourses_Courses_CourseId",
                table: "VisitorCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorCourses_Locations_LocationId",
                table: "VisitorCourses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorCourses_Visitors_VisitorId",
                table: "VisitorCourses",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "VisitorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Companies_CompanyId",
                table: "Visitors",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_References_CountryId",
                table: "Visitors",
                column: "CountryId",
                principalTable: "References",
                principalColumn: "ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_References_IDTypeId",
                table: "Visitors",
                column: "IDTypeId",
                principalTable: "References",
                principalColumn: "ReferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseVersions_Courses_CourseId",
                table: "CourseVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_References_CityId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_References_CountryId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_References_MunicipalityId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_References_ReferenceTypes_ReferenceTypeId",
                table: "References");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVehicles_Locations_LocationId",
                table: "TransactionVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVehicles_Vehicles_VehicleId",
                table: "TransactionVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVehicles_Visitors_EntryVisitorId",
                table: "TransactionVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVehicles_Visitors_ExitVisitorId",
                table: "TransactionVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVisitors_Locations_LocationId",
                table: "TransactionVisitors");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVisitors_References_ActivityId",
                table: "TransactionVisitors");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionVisitors_Visitors_VisitorId",
                table: "TransactionVisitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Companies_CompanyId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorCourses_ApplicationFiles_SignatureFileId",
                table: "VisitorCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorCourses_Courses_CourseId",
                table: "VisitorCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorCourses_Locations_LocationId",
                table: "VisitorCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorCourses_Visitors_VisitorId",
                table: "VisitorCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Companies_CompanyId",
                table: "Visitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_References_CountryId",
                table: "Visitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_References_IDTypeId",
                table: "Visitors");

            migrationBuilder.RenameColumn(
                name: "IDTypeId",
                table: "Visitors",
                newName: "IDType_ID");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Visitors",
                newName: "Country_ID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Visitors",
                newName: "Company_ID");

            migrationBuilder.RenameColumn(
                name: "VisitorId",
                table: "Visitors",
                newName: "Visitor_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_IDTypeId",
                table: "Visitors",
                newName: "IX_Visitors_IDType_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_CountryId",
                table: "Visitors",
                newName: "IX_Visitors_Country_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_CompanyId",
                table: "Visitors",
                newName: "IX_Visitors_Company_ID");

            migrationBuilder.RenameColumn(
                name: "VisitorId",
                table: "VisitorCourses",
                newName: "Visitor_ID");

            migrationBuilder.RenameColumn(
                name: "SignatureFileId",
                table: "VisitorCourses",
                newName: "SignatureFile_ID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "VisitorCourses",
                newName: "Location_ID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "VisitorCourses",
                newName: "Course_ID");

            migrationBuilder.RenameColumn(
                name: "VisitorCourseId",
                table: "VisitorCourses",
                newName: "VisitorCourse_ID");

            migrationBuilder.RenameIndex(
                name: "IX_VisitorCourses_VisitorId",
                table: "VisitorCourses",
                newName: "IX_VisitorCourses_Visitor_ID");

            migrationBuilder.RenameIndex(
                name: "IX_VisitorCourses_SignatureFileId",
                table: "VisitorCourses",
                newName: "IX_VisitorCourses_SignatureFile_ID");

            migrationBuilder.RenameIndex(
                name: "IX_VisitorCourses_LocationId",
                table: "VisitorCourses",
                newName: "IX_VisitorCourses_Location_ID");

            migrationBuilder.RenameIndex(
                name: "IX_VisitorCourses_CourseId",
                table: "VisitorCourses",
                newName: "IX_VisitorCourses_Course_ID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Vehicles",
                newName: "Company_ID");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Vehicles",
                newName: "Vehicle_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CompanyId",
                table: "Vehicles",
                newName: "IX_Vehicles_Company_ID");

            migrationBuilder.RenameColumn(
                name: "VisitorId",
                table: "TransactionVisitors",
                newName: "Visitor_ID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "TransactionVisitors",
                newName: "Location_ID");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "TransactionVisitors",
                newName: "Activity_ID");

            migrationBuilder.RenameColumn(
                name: "TransactionVisitorId",
                table: "TransactionVisitors",
                newName: "TransactionVisitor_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVisitors_VisitorId",
                table: "TransactionVisitors",
                newName: "IX_TransactionVisitors_Visitor_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVisitors_LocationId",
                table: "TransactionVisitors",
                newName: "IX_TransactionVisitors_Location_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVisitors_ActivityId",
                table: "TransactionVisitors",
                newName: "IX_TransactionVisitors_Activity_ID");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "TransactionVehicles",
                newName: "Vehicle_ID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "TransactionVehicles",
                newName: "Location_ID");

            migrationBuilder.RenameColumn(
                name: "ExitVisitorId",
                table: "TransactionVehicles",
                newName: "ExitVisitor_ID");

            migrationBuilder.RenameColumn(
                name: "EntryVisitorId",
                table: "TransactionVehicles",
                newName: "EntryVisitor_ID");

            migrationBuilder.RenameColumn(
                name: "TransactionVehicleId",
                table: "TransactionVehicles",
                newName: "TransactionVehicle_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVehicles_VehicleId",
                table: "TransactionVehicles",
                newName: "IX_TransactionVehicles_Vehicle_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVehicles_LocationId",
                table: "TransactionVehicles",
                newName: "IX_TransactionVehicles_Location_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVehicles_ExitVisitorId",
                table: "TransactionVehicles",
                newName: "IX_TransactionVehicles_ExitVisitor_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionVehicles_EntryVisitorId",
                table: "TransactionVehicles",
                newName: "IX_TransactionVehicles_EntryVisitor_ID");

            migrationBuilder.RenameColumn(
                name: "ReferenceTypeId",
                table: "ReferenceTypes",
                newName: "ReferenceType_ID");

            migrationBuilder.RenameColumn(
                name: "ReferenceTypeId",
                table: "References",
                newName: "ReferenceType_ID");

            migrationBuilder.RenameColumn(
                name: "ReferenceId",
                table: "References",
                newName: "Reference_ID");

            migrationBuilder.RenameIndex(
                name: "IX_References_ReferenceTypeId",
                table: "References",
                newName: "IX_References_ReferenceType_ID");

            migrationBuilder.RenameColumn(
                name: "OrganizationalUnitId",
                table: "OrganizationalUnits",
                newName: "OrganizationalUnit_ID");

            migrationBuilder.RenameColumn(
                name: "MunicipalityId",
                table: "Locations",
                newName: "Municipality_ID");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Locations",
                newName: "Country_ID");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Locations",
                newName: "City_ID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Locations",
                newName: "Location_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_MunicipalityId",
                table: "Locations",
                newName: "IX_Locations_Municipality_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                newName: "IX_Locations_Country_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                newName: "IX_Locations_City_ID");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Employee_ID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseVersions",
                newName: "Course_ID");

            migrationBuilder.RenameColumn(
                name: "CourseVersionId",
                table: "CourseVersions",
                newName: "CourseVersion_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseVersions_CourseId",
                table: "CourseVersions",
                newName: "IX_CourseVersions_Course_ID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Course_ID");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "Country_ID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companies",
                newName: "Company_ID");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Cities",
                newName: "Country_ID");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Cities",
                newName: "City_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                newName: "IX_Cities_Country_ID");

            migrationBuilder.RenameColumn(
                name: "ApplicationFileId",
                table: "ApplicationFiles",
                newName: "ApplicationFile_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_Country_ID",
                table: "Cities",
                column: "Country_ID",
                principalTable: "Countries",
                principalColumn: "Country_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVersions_Courses_Course_ID",
                table: "CourseVersions",
                column: "Course_ID",
                principalTable: "Courses",
                principalColumn: "Course_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_References_City_ID",
                table: "Locations",
                column: "City_ID",
                principalTable: "References",
                principalColumn: "Reference_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_References_Country_ID",
                table: "Locations",
                column: "Country_ID",
                principalTable: "References",
                principalColumn: "Reference_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_References_Municipality_ID",
                table: "Locations",
                column: "Municipality_ID",
                principalTable: "References",
                principalColumn: "Reference_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_References_ReferenceTypes_ReferenceType_ID",
                table: "References",
                column: "ReferenceType_ID",
                principalTable: "ReferenceTypes",
                principalColumn: "ReferenceType_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVehicles_Locations_Location_ID",
                table: "TransactionVehicles",
                column: "Location_ID",
                principalTable: "Locations",
                principalColumn: "Location_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVehicles_Vehicles_Vehicle_ID",
                table: "TransactionVehicles",
                column: "Vehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVehicles_Visitors_EntryVisitor_ID",
                table: "TransactionVehicles",
                column: "EntryVisitor_ID",
                principalTable: "Visitors",
                principalColumn: "Visitor_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVehicles_Visitors_ExitVisitor_ID",
                table: "TransactionVehicles",
                column: "ExitVisitor_ID",
                principalTable: "Visitors",
                principalColumn: "Visitor_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVisitors_Locations_Location_ID",
                table: "TransactionVisitors",
                column: "Location_ID",
                principalTable: "Locations",
                principalColumn: "Location_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVisitors_References_Activity_ID",
                table: "TransactionVisitors",
                column: "Activity_ID",
                principalTable: "References",
                principalColumn: "Reference_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionVisitors_Visitors_Visitor_ID",
                table: "TransactionVisitors",
                column: "Visitor_ID",
                principalTable: "Visitors",
                principalColumn: "Visitor_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Companies_Company_ID",
                table: "Vehicles",
                column: "Company_ID",
                principalTable: "Companies",
                principalColumn: "Company_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorCourses_ApplicationFiles_SignatureFile_ID",
                table: "VisitorCourses",
                column: "SignatureFile_ID",
                principalTable: "ApplicationFiles",
                principalColumn: "ApplicationFile_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorCourses_Courses_Course_ID",
                table: "VisitorCourses",
                column: "Course_ID",
                principalTable: "Courses",
                principalColumn: "Course_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorCourses_Locations_Location_ID",
                table: "VisitorCourses",
                column: "Location_ID",
                principalTable: "Locations",
                principalColumn: "Location_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorCourses_Visitors_Visitor_ID",
                table: "VisitorCourses",
                column: "Visitor_ID",
                principalTable: "Visitors",
                principalColumn: "Visitor_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Companies_Company_ID",
                table: "Visitors",
                column: "Company_ID",
                principalTable: "Companies",
                principalColumn: "Company_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_References_Country_ID",
                table: "Visitors",
                column: "Country_ID",
                principalTable: "References",
                principalColumn: "Reference_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_References_IDType_ID",
                table: "Visitors",
                column: "IDType_ID",
                principalTable: "References",
                principalColumn: "Reference_ID");
        }
    }
}
