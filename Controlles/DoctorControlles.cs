using Hospital_system.Data;
using Hospital_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Controlles
{
    public class DoctorControlles
    {
        public class DoctorService
        {
            private readonly ApplicationDbContext _context;

            public DoctorService(ApplicationDbContext context)
            {
                _context = context;
            }

            // Create
            public void AddDoctor(Doctor doctor)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
            }

            // Read
            public Doctor GetDoctorById(int id)
            {
                return _context.Doctors
                    .Include(d => d.MedicalRecords)
                    .Include(d => d.Appointments)
                    .SingleOrDefault(d => d.ID == id);
            }

            // Update
            public void UpdateDoctor(Doctor doctor)
            {
                _context.Doctors.Update(doctor);
                _context.SaveChanges();
            }

            // Delete
            public void DeleteDoctor(int id)
            {
                var doctor = _context.Doctors.Find(id);
                if (doctor != null)
                {
                    _context.Doctors.Remove(doctor);
                    _context.SaveChanges();
                }
            }
        }

    }
}
