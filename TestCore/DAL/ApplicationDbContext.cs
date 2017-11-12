// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AppointmentEntity> Appointments { get; set; }

        //public DbSet<DoctorEntity> Doctors { get; set; }

        public DbSet<EducationEntity> Educations { get; set; }

        public DbSet<ExperienceEntity> Experiences { get; set; }

        public DbSet<ReviewEntity> Reviews { get; set; }

        //public DbSet<PatientEntity> Patients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ReviewEntity>().HasOne(e => e.ApplicationUser).WithMany(e => e.Reviews)
                .HasForeignKey(e => e.ApplicationUserId);
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
