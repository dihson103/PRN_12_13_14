using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _07_Demo_2_3.Models;

public partial class Demo2Slot121314Context : DbContext
{
    public Demo2Slot121314Context()
    {
    }

    public Demo2Slot121314Context(DbContextOptions<Demo2Slot121314Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-LQOFJPF7\\SQLEXPRESS;Initial Catalog=Demo2_slot_12_13_14;User ID=sa;Password=12345;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A74EBBBEC7");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.CourseId }).HasName("PK__Enrollme__5E57FC83EB4E6B5C");

            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentDate).HasColumnType("date");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrollmen__Cours__3B75D760");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrollmen__Stude__3A81B327");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99B0B0F0EB");

            entity.ToTable("Student");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
