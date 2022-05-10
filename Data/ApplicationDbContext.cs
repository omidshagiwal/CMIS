using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CMIS.Models.Main_Models;
using System;
using System.Collections.Generic;
using System.Text;
using CMIS.Models;

namespace CMIS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LookUp_Province> LookUp_Province { get; set; }
        public DbSet<LookUp_District> LookUp_District { get; set; }
        public DbSet<LookUp_School> LookUp_School { get; set; }
        public DbSet<LookUp_Class> LookUp_Class { get; set; }
        public DbSet<LookUp_StudentSubject> LookUp_StudentSubject { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<EnrollmentStatus> EnrollmentStatus { get; set; }
        public DbSet<Year> Year { get; set; }
    }
}
