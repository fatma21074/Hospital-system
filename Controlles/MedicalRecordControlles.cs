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
    public class MedicalRecordControlles
    {
        public class MedicalRecordService
        {
            private readonly ApplicationDbContext _context;

            public MedicalRecordService(ApplicationDbContext context)
            {
                _context = context;
            }

            // Create
            public void AddMedicalRecord(MedicalRecord medicalRecord)
            {
                _context.MedicalRecords.Add(medicalRecord);
                _context.SaveChanges();
            }

            // Read
            public MedicalRecord GetMedicalRecordById(int id)
            {
                return _context.MedicalRecords
                    .Include(m => m.Treatments)
                    .SingleOrDefault(m => m.ID == id);
            }

            // Update
            public void UpdateMedicalRecord(MedicalRecord medicalRecord)
            {
                _context.MedicalRecords.Update(medicalRecord);
                _context.SaveChanges();
            }

            // Delete
            public void DeleteMedicalRecord(int id)
            {
                var medicalRecord = _context.MedicalRecords.Find(id);
                if (medicalRecord != null)
                {
                    _context.MedicalRecords.Remove(medicalRecord);
                    _context.SaveChanges();
                }
            }
        }

    }
}
