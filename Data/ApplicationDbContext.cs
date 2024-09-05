using Hospital_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Data
{
    public class ApplicationDbContext :DbContext

    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)// conction string علشان احط جواهاDbContextOptionsBuilder
        {
            options.UseSqlite("Data source=Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.MedicalRecords)
                .WithOne(m => m.Patient)
                .HasForeignKey(m => m.PatientId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.MedicalRecords)
                .WithOne(m => m.Doctor)
                .HasForeignKey(m => m.DoctorId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<MedicalRecord>()
                .HasMany(m => m.Treatments)
                .WithOne(t => t.MedicalRecord)
                .HasForeignKey(t => t.MedicalRecordId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Doctors)
                .WithOne(d => d.Department)
                .HasForeignKey(d => d.DepartmentId);
        }

    }
}
