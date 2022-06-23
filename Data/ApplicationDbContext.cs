using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using CMIS.Models;

namespace CMIS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //using FluentAPI
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Lookups
        public DbSet<LookupProvince> LookupProvinces { get; set; }
        public DbSet<LookupDistrict> LookupDistricts { get; set; }
        public DbSet<LookupSchool> LookupSchools { get; set; }
        public DbSet<LookupYear> LookupYears { get; set; }
        public DbSet<LookupClass> LookupClasses { get; set; }
        public DbSet<LookupSubject> LookupSubjects { get; set; }
        public DbSet<LookupEnrollmentStatus> LookupEnrollmentStatuses { get; set; }
        public DbSet<LookupSection> LookupSections { get; set; }
        public DbSet<LookupClassSubject> LookupClassSubjects { get; set; }
        public DbSet<LookupStudentStatus> LookUpStudentStatuses { get; set; }

        // Main Models
        public DbSet<SubjectOrder> SubjectsOrder { get; set; }
        public DbSet<ResultDocumentRegulation> ResultDocumentRegulations { get; set; }
        public DbSet<ResultDocument> ResultDocuments { get; set; }
        public DbSet<ResultDocumentStudent> ResultDocumentStudents { get; set; }
        public DbSet<StudentProfile> StudentsProfile { get; set; }
        public DbSet<ExamMark> ExamsMark { get; set; }
        public DbSet<StudentClassInfo> StudentClassesInfo { get; set; }
        public DbSet<StudentAttendance> StudentsAttendance { get; set; }


        public DbSet<ClassSection> ClassSections { get; set; }
        //public DbSet<Result_Document_Student> Result_Document_Student { get; set; }
        //public DbSet<Student_Class_Subject_Year> Student_Class_Subject_Year { get; set; }
        //public DbSet<Student_Issued_Certificate> Student_Issued_Certificate { get; set; }
        //public DbSet<StudentSubject> StudentSubject { get; set; } //no data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ResultDocumentStudent>()
                .HasKey(x => new { x.ResultDocumentId, x.AsasNumber });

            modelBuilder.Entity<ExamMark>()
                .HasKey(e => new { e.Id, e.StudentId, e.ClassId });

            modelBuilder.Entity<LookupSubject>(entity =>
            {
                entity.Property(r => r.Status).HasDefaultValue(true);
            });

            modelBuilder.Entity<StudentClassInfo>()
                .HasKey(p => new { p.StudentId, p.ClassId, p.GraduationYear });

            modelBuilder.Entity<StudentClassInfo>(entity =>
            {
                entity.Property(b => b.HasMarks).HasDefaultValue(true);
                entity.Property(x => x.InsertedDate).HasDefaultValue(DateTime.Now);
            });
        }
    }
}
