using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentManagmentSystem.Models
{
    public partial class SMSContext : DbContext
    {
        public SMSContext()
        {
        }

        public SMSContext(DbContextOptions<SMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<StudentReg> StudentRegViewMode { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseFees).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentReg>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__StudentR__32C52B992E9F1B6D");

                entity.ToTable("StudentReg");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StudentEmail)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentRegs)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__StudentRe__Cours__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
