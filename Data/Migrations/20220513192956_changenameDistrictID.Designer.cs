﻿// <auto-generated />
using System;
using CMIS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMIS.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220513192956_changenameDistrictID")]
    partial class changenameDistrictID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMIS.Models.LookUp_Class", b =>
                {
                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassID");

                    b.ToTable("LookUp_Class");
                });

            modelBuilder.Entity("CMIS.Models.LookUp_ClassSubject", b =>
                {
                    b.Property<int>("ClassSubjectID")
                        .HasColumnType("int");

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<int?>("LookUp_ClassClassID")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortNo")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("Student_SubjectSubjectID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("ClassSubjectID");

                    b.HasIndex("LookUp_ClassClassID");

                    b.HasIndex("Student_SubjectSubjectID");

                    b.ToTable("LookUp_ClassSubject");
                });

            modelBuilder.Entity("CMIS.Models.LookUp_District", b =>
                {
                    b.Property<int>("DistrictID")
                        .HasColumnType("int");

                    b.Property<int?>("DistrictIdNew")
                        .HasColumnType("int");

                    b.Property<string>("DistrictName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistrictNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.HasKey("DistrictID");

                    b.HasIndex("ProvinceID");

                    b.ToTable("LookUp_District");
                });

            modelBuilder.Entity("CMIS.Models.LookUp_Province", b =>
                {
                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProvinceNameDari")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinceNameEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinceNamePashto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceID");

                    b.ToTable("LookUp_Province");
                });

            modelBuilder.Entity("CMIS.Models.LookUp_School", b =>
                {
                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.Property<int>("CurrentStageId")
                        .HasColumnType("int");

                    b.Property<int>("DistrictID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EntryUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("SchoolNameDari")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolNamePashto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolNamePrevious")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolID");

                    b.HasIndex("DistrictID");

                    b.ToTable("LookUp_School");
                });

            modelBuilder.Entity("CMIS.Models.LookUp_Student_Status", b =>
                {
                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<string>("StatusEnglishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPashtoName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusID");

                    b.ToTable("LookUp_Student_Status");
                });

            modelBuilder.Entity("CMIS.Models.LookUp_Subject", b =>
                {
                    b.Property<int>("StudentSubjectID")
                        .HasColumnType("int");

                    b.Property<int?>("CertficateOrderNo")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewOrder")
                        .HasColumnType("int");

                    b.HasKey("StudentSubjectID");

                    b.ToTable("LookUp_Subject");
                });

            modelBuilder.Entity("CMIS.Models.Main_Models.LookUp_Section", b =>
                {
                    b.Property<int>("SectionID")
                        .HasColumnType("int");

                    b.Property<string>("SectionEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionID");

                    b.ToTable("LookUp_Section");
                });

            modelBuilder.Entity("CMIS.Models.Main_Models.LookUp_Year", b =>
                {
                    b.Property<int>("YearID")
                        .HasColumnType("int");

                    b.Property<string>("YearValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YearID");

                    b.ToTable("LookUp_Year");
                });

            modelBuilder.Entity("CMIS.Models.Main_Models.Lookup_Enrollment_Status", b =>
                {
                    b.Property<int>("EnrollmentStatusID")
                        .HasColumnType("int");

                    b.Property<string>("Condidtion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnrollmentStatusID");

                    b.ToTable("Lookup_Enrollment_Status");
                });

            modelBuilder.Entity("Directorate_Certificate_App.Models.Models.Student_Class_Info", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<int>("GraduationYear")
                        .HasColumnType("int");

                    b.Property<int>("AdmissionID")
                        .HasColumnType("int");

                    b.Property<string>("CenterSpecialistName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CenterVerified_By")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CenterVerified_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClassPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentOrderNo")
                        .HasColumnType("int");

                    b.Property<int>("EnrollmentStatusID")
                        .HasColumnType("int");

                    b.Property<Guid?>("InsertedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InsertedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsCenterVerified")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsFinalVerified")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRecordUpdated")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<int?>("LookUp_SchoolSchoolID")
                        .HasColumnType("int");

                    b.Property<int?>("LookUp_SectionSectionID")
                        .HasColumnType("int");

                    b.Property<int?>("Lookup_Enrollment_StatusEnrollmentStatusID")
                        .HasColumnType("int");

                    b.Property<Guid?>("PromotedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PromotedYear")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PromotionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SchoolID")
                        .HasColumnType("bigint");

                    b.Property<int>("SectionID")
                        .HasColumnType("int");

                    b.Property<string>("SpcialistName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentOrderNo")
                        .HasColumnType("int");

                    b.Property<int>("Student_Status_ID")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("VerifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("VerifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentID", "ClassID", "GraduationYear");

                    b.HasIndex("ClassID");

                    b.HasIndex("LookUp_SchoolSchoolID");

                    b.HasIndex("LookUp_SectionSectionID");

                    b.HasIndex("Lookup_Enrollment_StatusEnrollmentStatusID");

                    b.ToTable("Student_Class_Info");
                });

            modelBuilder.Entity("Directorate_Certificate_App.Models.Models.Student_Profile", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("ClassEnrollment")
                        .HasColumnType("int");

                    b.Property<long>("DateOfBirth")
                        .HasColumnType("bigint");

                    b.Property<string>("Entry_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Lookup_ProvinceProvinceID")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentEngName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentFatherEngName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentFatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StudentGender")
                        .HasColumnType("bit");

                    b.Property<string>("StudentGrandFatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentPicPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TazkiraNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThreeYearMarks")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("Lookup_ProvinceProvinceID");

                    b.ToTable("Student_Profile");
                });

            modelBuilder.Entity("Directorate_Certificate_App.Models.Models.Student_Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int>("CertificateOrderNo")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("SubjectEngName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewOrder")
                        .HasColumnType("int");

                    b.HasKey("SubjectID");

                    b.ToTable("Student_Subject");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CMIS.Models.LookUp_ClassSubject", b =>
                {
                    b.HasOne("CMIS.Models.LookUp_Class", "LookUp_Class")
                        .WithMany()
                        .HasForeignKey("LookUp_ClassClassID");

                    b.HasOne("Directorate_Certificate_App.Models.Models.Student_Subject", "Student_Subject")
                        .WithMany()
                        .HasForeignKey("Student_SubjectSubjectID");
                });

            modelBuilder.Entity("CMIS.Models.LookUp_District", b =>
                {
                    b.HasOne("CMIS.Models.LookUp_Province", "province")
                        .WithMany()
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CMIS.Models.LookUp_School", b =>
                {
                    b.HasOne("CMIS.Models.LookUp_District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Directorate_Certificate_App.Models.Models.Student_Class_Info", b =>
                {
                    b.HasOne("CMIS.Models.LookUp_Class", "LookUp_Class")
                        .WithMany()
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMIS.Models.LookUp_School", "LookUp_School")
                        .WithMany()
                        .HasForeignKey("LookUp_SchoolSchoolID");

                    b.HasOne("CMIS.Models.Main_Models.LookUp_Section", "LookUp_Section")
                        .WithMany()
                        .HasForeignKey("LookUp_SectionSectionID");

                    b.HasOne("CMIS.Models.Main_Models.Lookup_Enrollment_Status", "Lookup_Enrollment_Status")
                        .WithMany()
                        .HasForeignKey("Lookup_Enrollment_StatusEnrollmentStatusID");

                    b.HasOne("Directorate_Certificate_App.Models.Models.Student_Profile", "Student_Profile")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Directorate_Certificate_App.Models.Models.Student_Profile", b =>
                {
                    b.HasOne("CMIS.Models.LookUp_Province", "Lookup_Province")
                        .WithMany()
                        .HasForeignKey("Lookup_ProvinceProvinceID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
