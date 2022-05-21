using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CMIS.Models.Main_Models;
using System;
using System.Collections.Generic;
using System.Text;
using CMIS.Models;
using Directorate_Certificate_App.Models.Models;
using Directorate_Certificate_App.Models;

namespace CMIS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //LookUp Models
        public DbSet<LookUp_Province> LookUp_Province { get; set; }
        public DbSet<LookUp_District> LookUp_District { get; set; }
        public DbSet<LookUp_School> LookUp_School { get; set; }
        public DbSet<LookUp_Year> LookUp_Year { get; set; }
        public DbSet<LookUp_Class> LookUp_Class { get; set; }
        public DbSet<LookUp_Subject> LookUp_Subject { get; set; }
        public DbSet<Lookup_Enrollment_Status> Lookup_Enrollment_Status { get; set; }
        public DbSet<LookUp_Section> LookUp_Section { get; set; }
        public DbSet<LookUp_ClassSubject> LookUp_ClassSubject { get; set; }
        public DbSet<LookUp_Student_Status> LookUp_Student_Status { get; set; }


        //// Main Models
        //public DbSet<Class_Sections> Class_Sections { get; set; }
        //public DbSet<Result_Document> Result_Documents { get; set; }
        //public DbSet<Result_Document_Student> Result_Document_Student { get; set; }
        //public DbSet<Student_Attendence> Student_Attendence { get; set; }
        //public DbSet<Student_Class_Info> Student_Class_Info { get; set; } //key
        //public DbSet<Student_Class_Subject_Year> Student_Class_Subject_Year { get; set; }
        //public DbSet<Student_Issued_Certificate> Student_Issued_Certificate { get; set; } //key
        public DbSet<StudentProfile> StudentProfiles { get; set; } //key
        //public DbSet<Student_Subject> Student_Subject { get; set; } //no data
        //public DbSet<Student_Subject_Exam_Marks> Student_Subject_Exam_Marks { get; set; }
    }
}
