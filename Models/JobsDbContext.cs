using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobsAPIProject.Models;

public partial class JobsDbContext : DbContext
{
    public JobsDbContext()
    {
    }

    public JobsDbContext(DbContextOptions<JobsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__DEPARTME__63E6136221A2156A");

            entity.ToTable("DEPARTMENTS");

            entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
            entity.Property(e => e.DepartmentTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_TITLE");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__JOBS__2AC9D60ACC81946E");

            entity.ToTable("JOBS");

            entity.Property(e => e.JobId).HasColumnName("JOB_ID");
            entity.Property(e => e.ClosingDate)
                .HasColumnType("datetime")
                .HasColumnName("CLOSING_DATE");
            entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
            entity.Property(e => e.JobCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasComputedColumnSql("('JOB-'+right('0'+CONVERT([varchar](8),[JOB_ID]),(8)))", true)
                .HasColumnName("JOB_CODE");
            entity.Property(e => e.JobDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("JOB_DESCRIPTION");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("JOB_TITLE");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.PostedDate)
                .HasColumnType("datetime")
                .HasColumnName("POSTED_DATE");

            entity.HasOne(d => d.Department).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__JOBS__DEPARTMENT__3B75D760");

            entity.HasOne(d => d.Location).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__JOBS__LOCATION_I__3A81B327");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__LOCATION__D2263B8E2E77FABC");

            entity.ToTable("LOCATIONS");

            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.LocationCity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATION_CITY");
            entity.Property(e => e.LocationCountry)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATION_COUNTRY");
            entity.Property(e => e.LocationState)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATION_STATE");
            entity.Property(e => e.LocationTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATION_TITLE");
            entity.Property(e => e.LocationZip).HasColumnName("LOCATION_ZIP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
