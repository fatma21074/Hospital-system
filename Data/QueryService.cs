using Hospital_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Data
{
    public class QueryService
    {
        private readonly ApplicationDbContext _context;

        public QueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Query: Retrieve a list of all doctors who have treated a specific patient
        public List<Doctor> GetDoctorsForPatient(int patientId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Doctors
                    .Where(d => d.MedicalRecords.Any(m => m.PatientId == patientId))
                    .ToList();
            }
        }

        // Query: Generate a list of all patients treated by doctors in a specific department over the last month
        public List<Patient> GetPatientsTreatedInDepartment(int departmentId, DateTime startDate, DateTime endDate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Patients
                    .Where(p => p.MedicalRecords.Any(m => m.Doctor.DepartmentId == departmentId && m.DateCreated >= startDate && m.DateCreated <= endDate))
                    .ToList();
            }
        }

        // Report: List all patients who have appointments scheduled in the next week, along with their doctor’s contact information
        public List<Appointment> GetUpcomingAppointments()
        {
            var nextWeek = DateTime.Now.AddDays(7);
            using (var context = new ApplicationDbContext())
            {
                return context.Appointments
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor)
                    .Where(a => a.AppointmentDate <= nextWeek)
                    .ToList();
            }
        }

        // Report: Generate a report showing the total number of patients treated per department over a given period
        public Dictionary<string, int> GetPatientCountPerDepartment(DateTime startDate, DateTime endDate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Departments
                    .Select(d => new
                    {
                        DepartmentName = d.Name,
                        PatientCount = d.Doctors
                            .SelectMany(doc => doc.MedicalRecords)
                            .Where(m => m.DateCreated >= startDate && m.DateCreated <= endDate)
                            .Select(m => m.PatientId)
                            .Distinct()
                            .Count()
                    })
                    .ToDictionary(x => x.DepartmentName, x => x.PatientCount);
            }
        }

        // Report: Create a report that displays the average time spent on each type of treatment and identify any outliers
        public Dictionary<string, double> GetAverageTreatmentTimes()
        {
            using (var context = new ApplicationDbContext())
            {
                var treatmentTimes = context.Treatments
                    .GroupBy(t => t.TreatmentType)
                    .Select(g => new
                    {
                        TreatmentType = g.Key,
                        AverageTime = g.Average(t => (DateTime.Now - t.TreatmentDate).TotalHours) // Example of time spent
                    })
                    .ToDictionary(x => x.TreatmentType, x => x.AverageTime);

                return treatmentTimes;
            }
        }
        // Report: Develop a method to list the top 5 most active doctors based on the number of patients they have treated
        public  List<Doctor> GetTopActiveDoctors(int topN)
        {
            using (var context = new ApplicationDbContext())
            {
                return _context.MedicalRecords
        .GroupBy(mr => mr.Doctor)
        .OrderByDescending(g => g.Select(mr => mr.Patient).Distinct().Count())
        .Take(5)
        .Select(g => new Doctor
        {
            DoctorName = g.Key.FirstName + " " + g.Key.LastName,
            PatientCount = g.Select(mr => mr.Patient).Distinct().Count()
        })
        .ToList();
            }
        }
    }
}


