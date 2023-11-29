﻿// <auto-generated />
using System;
using AttendanceManagementSystem.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AttendanceManagementSystem.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeOnly>("AttendanceTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("DayOfWeek")
                        .HasColumnType("tinyint");

                    b.Property<TimeOnly>("DepartureTime")
                        .HasColumnType("time");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.AttendanceReport", b =>
                {
                    b.Property<Guid>("ReportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AttendanceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReportId", "AttendanceId");

                    b.HasIndex("AttendanceId");

                    b.ToTable("AttendanceReports");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.LeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LeaveEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeaveStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeaveStatus")
                        .HasColumnType("int");

                    b.Property<int>("LeaveType")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("User")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.LeaveRequestReport", b =>
                {
                    b.Property<Guid>("ReportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LeaveRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReportId", "LeaveRequestId");

                    b.HasIndex("LeaveRequestId");

                    b.ToTable("LeaveRequestReports");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Payroll", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BaseSalary")
                        .HasColumnType("decimal(7, 2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("PayPeriodStart")
                        .HasColumnType("date");

                    b.Property<DateOnly>("PayPerionEnd")
                        .HasColumnType("date");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("TotalPay")
                        .HasColumnType("decimal(7, 2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("User")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payrolls");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.PayrollReport", b =>
                {
                    b.Property<Guid>("ReportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PayrollId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReportId", "PayrollId");

                    b.HasIndex("PayrollId");

                    b.ToTable("PayrollReports");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReportDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportType")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("User")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkDays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Attendance", b =>
                {
                    b.HasOne("AttendanceManagementSystem.Domain.Models.User", null)
                        .WithMany("Attendances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.AttendanceReport", b =>
                {
                    b.HasOne("AttendanceManagementSystem.Domain.Models.Attendance", "Attendance")
                        .WithMany("AttendanceReports")
                        .HasForeignKey("AttendanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttendanceManagementSystem.Domain.Models.Report", "Report")
                        .WithMany("AttendanceReports")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendance");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.LeaveRequest", b =>
                {
                    b.HasOne("AttendanceManagementSystem.Domain.Models.User", null)
                        .WithMany("LeaveRequests")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.LeaveRequestReport", b =>
                {
                    b.HasOne("AttendanceManagementSystem.Domain.Models.LeaveRequest", "LeaveRequest")
                        .WithMany("LeaveRequestReports")
                        .HasForeignKey("LeaveRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttendanceManagementSystem.Domain.Models.Report", "Report")
                        .WithMany("LeaveRequestReports")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaveRequest");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Payroll", b =>
                {
                    b.HasOne("AttendanceManagementSystem.Domain.Models.User", null)
                        .WithMany("Payrolls")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.PayrollReport", b =>
                {
                    b.HasOne("AttendanceManagementSystem.Domain.Models.Payroll", "Payroll")
                        .WithMany("PayrollReports")
                        .HasForeignKey("PayrollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttendanceManagementSystem.Domain.Models.Report", "Report")
                        .WithMany("PayrollReports")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payroll");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Report", b =>
                {
                    b.HasOne("AttendanceManagementSystem.Domain.Models.User", null)
                        .WithMany("Reports")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Schedule", b =>
                {
                    b.HasOne("AttendanceManagementSystem.Domain.Models.User", null)
                        .WithOne("Schedule")
                        .HasForeignKey("AttendanceManagementSystem.Domain.Models.Schedule", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Attendance", b =>
                {
                    b.Navigation("AttendanceReports");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.LeaveRequest", b =>
                {
                    b.Navigation("LeaveRequestReports");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Payroll", b =>
                {
                    b.Navigation("PayrollReports");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.Report", b =>
                {
                    b.Navigation("AttendanceReports");

                    b.Navigation("LeaveRequestReports");

                    b.Navigation("PayrollReports");
                });

            modelBuilder.Entity("AttendanceManagementSystem.Domain.Models.User", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("LeaveRequests");

                    b.Navigation("Payrolls");

                    b.Navigation("Reports");

                    b.Navigation("Schedule")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
