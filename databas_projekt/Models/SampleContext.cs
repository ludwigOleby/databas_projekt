using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace databas_projekt.Models
{
    public partial class SampleContext : DbContext
    {
        public SampleContext()
        {
        }

        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<Kurs> Kurs { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source = SPELDATOR; Initial Catalog = Projekt; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FkstudentId).HasColumnName("FKStudentId");

                entity.Property(e => e.Fkteacher).HasColumnName("FKTeacher");

                entity.HasOne(d => d.Fkstudent)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.FkstudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Students1");

                entity.HasOne(d => d.FkteacherNavigation)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.Fkteacher)
                    .HasConstraintName("FK_Class_Employee");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.PkdepartmentId);

                entity.Property(e => e.PkdepartmentId)
                    .HasColumnName("PKDepartmentId")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("departmentName")
                    .HasMaxLength(50);

                entity.Property(e => e.FkemployeeId).HasColumnName("FKEmployeeID");

                entity.HasOne(d => d.Pkdepartment)
                    .WithOne(p => p.Departments)
                    .HasForeignKey<Departments>(d => d.PkdepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Roll).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Grades>(entity =>
            {
                entity.HasKey(e => e.GradeId);

                entity.Property(e => e.FkstaffId).HasColumnName("FKStaffId");

                entity.Property(e => e.GradeDate).HasColumnType("date");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Grades_Class");

                entity.HasOne(d => d.Fkstaff)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.FkstaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Employee");

                entity.HasOne(d => d.StudentGrade)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentGradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Students");
            });

            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.FkstudentId).HasColumnName("FKStudentId");

                entity.Property(e => e.FkteacherId).HasColumnName("FKTeacherID");

                entity.Property(e => e.PkcourseId).HasColumnName("PKCourseId");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Fkstudent)
                    .WithMany()
                    .HasForeignKey(d => d.FkstudentId)
                    .HasConstraintName("FK_Kurs_Students");

                entity.HasOne(d => d.Fkteacher)
                    .WithMany()
                    .HasForeignKey(d => d.FkteacherId)
                    .HasConstraintName("FK_Kurs_Employee");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
