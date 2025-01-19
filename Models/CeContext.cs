using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Models;

public partial class CeContext : DbContext
{
    public CeContext()
    {
    }

    public CeContext(DbContextOptions<CeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bu> Bus { get; set; }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=cockysql.database.windows.net;Database=ce;Trusted_Connection=False;User=cockysa;Password=*Columbia1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bu__3213E83F2077F32C");

            entity.ToTable("bu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Buhqaddress1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("buhqaddress1");
            entity.Property(e => e.Buhqaddress2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("buhqaddress2");
            entity.Property(e => e.Buhqcity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("buhqcity");
            entity.Property(e => e.Buhqpostal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("buhqpostal");
            entity.Property(e => e.Buhqstate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("buhqstate");
            entity.Property(e => e.Buname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("buname");
        });

        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__certific__3213E83FEF86E21A");

            entity.ToTable("certifications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bu).HasColumnName("bu");
            entity.Property(e => e.Certdate)
                .HasColumnType("datetime")
                .HasColumnName("certdate");
            entity.Property(e => e.Certname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("certname");
            entity.Property(e => e.Comments)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employeeid");
            entity.Property(e => e.Revisedate)
                .HasColumnType("datetime")
                .HasColumnName("revisedate");
            entity.Property(e => e.Revision)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("revision");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83FD5F88ACC");

            entity.ToTable("employees");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EmployeeReturndate)
                .HasColumnType("datetime")
                .HasColumnName("employee_returndate");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employeeid");
            entity.Property(e => e.Employeestartdate)
                .HasColumnType("datetime")
                .HasColumnName("employeestartdate");
            entity.Property(e => e.Employeetenure)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employeetenure");
            entity.Property(e => e.Hrid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hrid");
            entity.Property(e => e.Hrsystemconstring)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("hrsystemconstring");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F9BCFF285");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employeeid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
