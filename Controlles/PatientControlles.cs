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
    public class PatientControlles
    {
        public class PatientService
        {
            private readonly ApplicationDbContext _context;

            public PatientService(ApplicationDbContext context)
            {
                _context = context;
            }

            // Create
            public void AddPatient(Patient patient)
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
            }

            // Read
            public Patient GetPatientById(int id)
            {
                return _context.Patients
                    .Include(p => p.MedicalRecords)
                    .ThenInclude(m => m.Treatments)
                    .Include(p => p.Appointments)
                    .SingleOrDefault(p => p.ID == id);
            }

            // Update
            public void UpdatePatient(Patient patient)
            {
                _context.Patients.Update(patient);
                _context.SaveChanges();
            }

            // Delete
            public void DeletePatient(int id)
            {
                var patient = _context.Patients.Find(id);
                if (patient != null)
                {
                    _context.Patients.Remove(patient);
                    _context.SaveChanges();
                }
            }
        }

    }
}
