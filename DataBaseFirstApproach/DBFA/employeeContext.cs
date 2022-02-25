using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataBaseFirstApproach.DBFA
{
    public partial class employeeContext : DbContext
    {
        public employeeContext()
        {
        }

        public employeeContext(DbContextOptions<employeeContext> options) : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Emp> Emps { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Incentive> Incentives { get; set; }
        public virtual DbSet<VwEmp> VwEmps { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7EMM0NQ\\SQL2019;Database=employee;Integrated Security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK_department_1");

                entity.ToTable("department");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dept_name");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.ToTable("emp");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.Doj)
                    .HasColumnType("date")
                    .HasColumnName("doj");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("f_name");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Employee_id");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Joining_date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");
            });

            modelBuilder.Entity<Incentive>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmployeeRefId).HasColumnName("Employee_ref_id");

                entity.Property(e => e.IncentiveAmount).HasColumnName("Incentive_amount");

                entity.Property(e => e.IncentiveDate)
                    .HasColumnType("date")
                    .HasColumnName("Incentive_date");

                entity.HasOne(d => d.EmployeeRef)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeRefId)
                    .HasConstraintName("FK_Incentives_Employee");
            });

            modelBuilder.Entity<VwEmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_emp");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.Doj)
                    .HasColumnType("date")
                    .HasColumnName("doj");

                entity.Property(e => e.EmpId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("emp_id");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("f_name");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
