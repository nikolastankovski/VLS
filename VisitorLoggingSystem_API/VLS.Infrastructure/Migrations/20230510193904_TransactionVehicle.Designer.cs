﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VLS.Infrastructure.Data;

#nullable disable

namespace VLS.Infrastructure.Migrations
{
    [DbContext(typeof(VLSDbContext))]
    [Migration("20230510193904_TransactionVehicle")]
    partial class TransactionVehicle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VLS.Domain.DbModels.ApplicationFile", b =>
                {
                    b.Property<int>("ApplicationFile_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationFile_ID"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ApplicationFile_ID");

                    b.ToTable("ApplicationFiles");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Company", b =>
                {
                    b.Property<int>("Company_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Company_ID"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IDNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Company_ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Course", b =>
                {
                    b.Property<int>("Course_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Course_ID"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Course_ID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.CourseVersion", b =>
                {
                    b.Property<int>("CourseVersion_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseVersion_ID"));

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ValidTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("ValidityPeriodInMonths")
                        .HasColumnType("int");

                    b.HasKey("CourseVersion_ID");

                    b.HasIndex("Course_ID");

                    b.ToTable("CourseVersions");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Employee", b =>
                {
                    b.Property<int>("Employee_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Employee_ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("OrganizationalUnitCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Employee_ID");

                    b.HasIndex("OrganizationalUnitCode");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Location", b =>
                {
                    b.Property<int>("Location_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Location_ID"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("City_ID")
                        .HasColumnType("int");

                    b.Property<int>("Country_ID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Municipality_ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Location_ID");

                    b.HasIndex("City_ID");

                    b.HasIndex("Country_ID");

                    b.HasIndex("Municipality_ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.OrganizationalUnit", b =>
                {
                    b.Property<int>("OrganizationalUnit_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationalUnit_ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("OrganizationalUnit_ID");

                    b.ToTable("OrganizationalUnits");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Reference", b =>
                {
                    b.Property<int>("Reference_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reference_ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReferenceType_ID")
                        .HasColumnType("int");

                    b.HasKey("Reference_ID");

                    b.HasIndex("ReferenceType_ID");

                    b.ToTable("References");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.ReferenceType", b =>
                {
                    b.Property<int>("ReferenceType_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReferenceType_ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("ReferenceType_ID");

                    b.ToTable("ReferenceTypes");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.TransactionVehicle", b =>
                {
                    b.Property<long>("TransactionVehicle_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TransactionVehicle_ID"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EntryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("EntryVisitor_ID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ExitDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ExitVisitor_ID")
                        .HasColumnType("bigint");

                    b.Property<int>("Location_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("Vehicle_ID")
                        .HasColumnType("bigint");

                    b.HasKey("TransactionVehicle_ID");

                    b.HasIndex("EntryVisitor_ID");

                    b.HasIndex("ExitVisitor_ID");

                    b.HasIndex("Location_ID");

                    b.HasIndex("Vehicle_ID");

                    b.ToTable("TransactionVehicles");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.TransactionVisitor", b =>
                {
                    b.Property<long>("TransactionVisitor_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TransactionVisitor_ID"));

                    b.Property<int>("Activity_ID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EntryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExitDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Incident")
                        .HasColumnType("bit");

                    b.Property<string>("IncidentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrganizationUnitCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SpecificPlace")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("VehicleRegistrationNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VisiteeCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Visitor_ID")
                        .HasColumnType("bigint");

                    b.HasKey("TransactionVisitor_ID");

                    b.HasIndex("Activity_ID");

                    b.HasIndex("Location_ID");

                    b.HasIndex("OrganizationUnitCode");

                    b.HasIndex("VisiteeCode");

                    b.HasIndex("Visitor_ID");

                    b.ToTable("TransactionVisitors");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Vehicle", b =>
                {
                    b.Property<long>("Vehicle_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Vehicle_ID"));

                    b.Property<int>("Company_ID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("TechnicalCorrectnessExpireDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Vehicle_ID");

                    b.HasIndex("Company_ID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Visitor", b =>
                {
                    b.Property<long>("Visitor_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Visitor_ID"));

                    b.Property<int?>("Company_ID")
                        .HasColumnType("int");

                    b.Property<int>("Country_ID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("IDExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IDNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IDType_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Visitor_ID");

                    b.HasIndex("Company_ID");

                    b.HasIndex("Country_ID");

                    b.HasIndex("IDType_ID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.VisitorCourse", b =>
                {
                    b.Property<int>("VisitorCourse_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitorCourse_ID"));

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCourseTaken")
                        .HasColumnType("datetime2");

                    b.Property<int>("Location_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("SignatureFile_ID")
                        .HasColumnType("int");

                    b.Property<long>("Visitor_ID")
                        .HasColumnType("bigint");

                    b.HasKey("VisitorCourse_ID");

                    b.HasIndex("Course_ID");

                    b.HasIndex("Location_ID");

                    b.HasIndex("SignatureFile_ID");

                    b.HasIndex("Visitor_ID");

                    b.ToTable("VisitorCourses");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.CourseVersion", b =>
                {
                    b.HasOne("VLS.Domain.DbModels.Course", "Course")
                        .WithMany("CourseVersions")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Employee", b =>
                {
                    b.HasOne("VLS.Domain.DbModels.OrganizationalUnit", "OrganizationalUnit")
                        .WithMany("Employees")
                        .HasForeignKey("OrganizationalUnitCode")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganizationalUnit");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Location", b =>
                {
                    b.HasOne("VLS.Domain.DbModels.Reference", "City")
                        .WithMany("Cities")
                        .HasForeignKey("City_ID");

                    b.HasOne("VLS.Domain.DbModels.Reference", "Country")
                        .WithMany("LocationCountries")
                        .HasForeignKey("Country_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.Reference", "Municipality")
                        .WithMany("Municipalities")
                        .HasForeignKey("Municipality_ID");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Reference", b =>
                {
                    b.HasOne("VLS.Domain.DbModels.ReferenceType", "ReferenceType")
                        .WithMany("References")
                        .HasForeignKey("ReferenceType_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReferenceType");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.TransactionVehicle", b =>
                {
                    b.HasOne("VLS.Domain.DbModels.Visitor", "EntryVisitor")
                        .WithMany("EntryVisitors")
                        .HasForeignKey("EntryVisitor_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.Visitor", "ExitVisitor")
                        .WithMany("ExitVisitors")
                        .HasForeignKey("ExitVisitor_ID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("VLS.Domain.DbModels.Location", "Location")
                        .WithMany("TransactionVehicles")
                        .HasForeignKey("Location_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.Vehicle", "Vehicle")
                        .WithMany("TransactionVehicles")
                        .HasForeignKey("Vehicle_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EntryVisitor");

                    b.Navigation("ExitVisitor");

                    b.Navigation("Location");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.TransactionVisitor", b =>
                {
                    b.HasOne("VLS.Domain.DbModels.Reference", "Activity")
                        .WithMany("TransactionVisitors")
                        .HasForeignKey("Activity_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.Location", "Location")
                        .WithMany("TransactionVisitors")
                        .HasForeignKey("Location_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.OrganizationalUnit", "OrganizationalUnit")
                        .WithMany("TransactionVisitors")
                        .HasForeignKey("OrganizationUnitCode")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.Employee", "Visitee")
                        .WithMany("TransactionVisitors")
                        .HasForeignKey("VisiteeCode")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("VLS.Domain.DbModels.Visitor", "Visitor")
                        .WithMany("TransactionVisitors")
                        .HasForeignKey("Visitor_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Location");

                    b.Navigation("OrganizationalUnit");

                    b.Navigation("Visitee");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Vehicle", b =>
                {
                    b.HasOne("VLS.Domain.DbModels.Company", "Company")
                        .WithMany("Vehicles")
                        .HasForeignKey("Company_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Visitor", b =>
                {
                    b.HasOne("VLS.Domain.DbModels.Company", "Company")
                        .WithMany("Visitors")
                        .HasForeignKey("Company_ID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("VLS.Domain.DbModels.Reference", "Country")
                        .WithMany("VisitorCountries")
                        .HasForeignKey("Country_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.Reference", "IDType")
                        .WithMany("IDTypes")
                        .HasForeignKey("IDType_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Country");

                    b.Navigation("IDType");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.VisitorCourse", b =>
                {
                    b.HasOne("VLS.Domain.DbModels.Course", "Course")
                        .WithMany("VisitorCourses")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.Location", "Location")
                        .WithMany("VisitorCourses")
                        .HasForeignKey("Location_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.ApplicationFile", "SignatureFile")
                        .WithMany("VisitorCourses")
                        .HasForeignKey("SignatureFile_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VLS.Domain.DbModels.Visitor", "Visitor")
                        .WithMany("VisitorCourses")
                        .HasForeignKey("Visitor_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Location");

                    b.Navigation("SignatureFile");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.ApplicationFile", b =>
                {
                    b.Navigation("VisitorCourses");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Company", b =>
                {
                    b.Navigation("Vehicles");

                    b.Navigation("Visitors");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Course", b =>
                {
                    b.Navigation("CourseVersions");

                    b.Navigation("VisitorCourses");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Employee", b =>
                {
                    b.Navigation("TransactionVisitors");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Location", b =>
                {
                    b.Navigation("TransactionVehicles");

                    b.Navigation("TransactionVisitors");

                    b.Navigation("VisitorCourses");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.OrganizationalUnit", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("TransactionVisitors");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Reference", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("IDTypes");

                    b.Navigation("LocationCountries");

                    b.Navigation("Municipalities");

                    b.Navigation("TransactionVisitors");

                    b.Navigation("VisitorCountries");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.ReferenceType", b =>
                {
                    b.Navigation("References");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Vehicle", b =>
                {
                    b.Navigation("TransactionVehicles");
                });

            modelBuilder.Entity("VLS.Domain.DbModels.Visitor", b =>
                {
                    b.Navigation("EntryVisitors");

                    b.Navigation("ExitVisitors");

                    b.Navigation("TransactionVisitors");

                    b.Navigation("VisitorCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
