﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using company.DAL.Entity;

#nullable disable

namespace company.DAL.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20231007133420_edittabel")]
    partial class edittabel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("company.DAL.Repository.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_departments");

                    b.ToTable("Departments", "hr");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.bonuss", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("Bonusflag")
                        .HasColumnType("bit");

                    b.Property<string>("bonusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("bonusValue")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("bonuss", "hr");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("date");

                    b.Property<int>("deprtmentId")
                        .HasColumnType("int");

                    b.Property<string>("employeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("date");

                    b.Property<int>("genderId")
                        .HasColumnType("int");

                    b.Property<bool?>("isAvtive")
                        .HasColumnType("bit");

                    b.Property<int?>("jobId")
                        .HasColumnType("int");

                    b.Property<string>("nationalId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phone1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phone2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("religionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("date");

                    b.HasKey("id");

                    b.HasIndex("deprtmentId");

                    b.HasIndex("genderId");

                    b.HasIndex("jobId");

                    b.HasIndex("religionId");

                    b.ToTable("employees", "hr");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.employeesBonu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("bonusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("date");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("bonusId");

                    b.HasIndex("employeeId");

                    b.ToTable("employeesBonus", "hr");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.employeesVacation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fromDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("toDate")
                        .HasColumnType("datetime");

                    b.Property<int>("vacationId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("employeeId");

                    b.HasIndex("vacationId");

                    b.ToTable("employeesVacations", "hr");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.gender", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("genderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("gender", "hr");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.job", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("jobName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("salary")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("jobs", "hr");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.religion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("religionName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("religions", "hr");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.vacation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double>("vacationCost")
                        .HasColumnType("float");

                    b.Property<string>("vacationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("vacations", "hr");
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

            modelBuilder.Entity("company.DAL.Repository.Models.employee", b =>
                {
                    b.HasOne("company.DAL.Repository.Models.Department", "deprtment")
                        .WithMany("employees")
                        .HasForeignKey("deprtmentId")
                        .IsRequired()
                        .HasConstraintName("FK_employees_Departments");

                    b.HasOne("company.DAL.Repository.Models.gender", "gender")
                        .WithMany("employees")
                        .HasForeignKey("genderId")
                        .IsRequired()
                        .HasConstraintName("FK_employees_gender");

                    b.HasOne("company.DAL.Repository.Models.job", "job")
                        .WithMany("employees")
                        .HasForeignKey("jobId")
                        .HasConstraintName("FK_employees_jobs");

                    b.HasOne("company.DAL.Repository.Models.religion", "religion")
                        .WithMany("employees")
                        .HasForeignKey("religionId")
                        .IsRequired()
                        .HasConstraintName("FK_employees_religions");

                    b.Navigation("deprtment");

                    b.Navigation("gender");

                    b.Navigation("job");

                    b.Navigation("religion");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.employeesBonu", b =>
                {
                    b.HasOne("company.DAL.Repository.Models.bonuss", "bonus")
                        .WithMany("employeesBonus")
                        .HasForeignKey("bonusId")
                        .IsRequired()
                        .HasConstraintName("FK_employeesBonus_bonuss");

                    b.HasOne("company.DAL.Repository.Models.employee", "employee")
                        .WithMany("employeesBonus")
                        .HasForeignKey("employeeId")
                        .IsRequired()
                        .HasConstraintName("FK_employeesBonus_employees");

                    b.Navigation("bonus");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.employeesVacation", b =>
                {
                    b.HasOne("company.DAL.Repository.Models.employee", "employee")
                        .WithMany("employeesVacations")
                        .HasForeignKey("employeeId")
                        .IsRequired()
                        .HasConstraintName("FK_employeesVacations_employees");

                    b.HasOne("company.DAL.Repository.Models.vacation", "vacation")
                        .WithMany("employeesVacations")
                        .HasForeignKey("vacationId")
                        .IsRequired()
                        .HasConstraintName("FK_employeesVacations_vacations");

                    b.Navigation("employee");

                    b.Navigation("vacation");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.Department", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.bonuss", b =>
                {
                    b.Navigation("employeesBonus");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.employee", b =>
                {
                    b.Navigation("employeesBonus");

                    b.Navigation("employeesVacations");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.gender", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.job", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.religion", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("company.DAL.Repository.Models.vacation", b =>
                {
                    b.Navigation("employeesVacations");
                });
#pragma warning restore 612, 618
        }
    }
}