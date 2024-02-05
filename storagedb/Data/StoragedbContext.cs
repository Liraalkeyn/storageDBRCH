using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using storagedb.Models;

namespace storagedb.Data;

public partial class StoragedbContext : DbContext
{
    public StoragedbContext()
    {
    }

    public StoragedbContext(DbContextOptions<StoragedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=storagedb;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("department_pkey");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId).HasColumnName("departmentID");
            entity.Property(e => e.NameOfDepartment)
                .HasColumnType("character varying")
                .HasColumnName("nameOfDepartment");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.DepartmentId).HasColumnName("departmentID");
            entity.Property(e => e.NameOfEmployee)
                .HasColumnType("character varying")
                .HasColumnName("nameOfEmployee");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("departmentID");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order_pkey");

            entity.ToTable("order");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.NameOfOrder)
                .HasColumnType("character varying")
                .HasColumnName("nameOfOrder");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
