using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using company.DAL.Extend;
using Microsoft.AspNetCore.Identity;

namespace company.DAL.Entity;


    public class CompanyContext: IdentityDbContext<ApplicationUser, ApplictionRoles, string>
{ 
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<bonuss> bonusses { get; set; }

    public virtual DbSet<employee> employees { get; set; }

    public virtual DbSet<employeesBonu> employeesBonus { get; set; }

    public virtual DbSet<employeesVacation> employeesVacations { get; set; }

    public virtual DbSet<gender> genders { get; set; }



    public virtual DbSet<job> jobs { get; set; }



    public virtual DbSet<religion> religions { get; set; }


    public virtual DbSet<vacation> vacations { get; set; }

    public virtual DbSet<Pages> Pages { get; set; }

    public virtual DbSet<RolesPage> RolesPages { get; set; }



    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("data source=DESKTOP-GDRF01I;initial catalog=company2;integrated security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;App=EntityFramework");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder); 
    //    modelBuilder.Entity<Department>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK_departments");
    //    });

    //    modelBuilder.Entity<employee>(entity =>
    //    {
    //        entity.HasOne(d => d.deprtment).WithMany(p => p.employees)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_employees_Departments");

    //        entity.HasOne(d => d.gender).WithMany(p => p.employees)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_employees_gender");

    //        entity.HasOne(d => d.job).WithMany(p => p.employees).HasConstraintName("FK_employees_jobs");

    //        entity.HasOne(d => d.religion).WithMany(p => p.employees)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_employees_religions");
    //    });

    //    modelBuilder.Entity<employeesBonu>(entity =>
    //    {
    //        entity.HasOne(d => d.bonus).WithMany(p => p.employeesBonus)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_employeesBonus_bonuss");

    //        entity.HasOne(d => d.employee).WithMany(p => p.employeesBonus)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_employeesBonus_employees");
    //    });

    //    modelBuilder.Entity<employeesVacation>(entity =>
    //    {
    //        entity.HasOne(d => d.employee).WithMany(p => p.employeesVacations)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_employeesVacations_employees");

    //        entity.HasOne(d => d.vacation).WithMany(p => p.employeesVacations)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_employeesVacations_vacations");
    //    });

        

       


    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
