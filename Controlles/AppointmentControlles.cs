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
    public class AppointmentControlles
    {
        public class AppointmentService
        {
            private readonly ApplicationDbContext _context;

            public AppointmentService(ApplicationDbContext context)
            {
                _context = context;
            }

            // Create
            public void AddAppointment(Appointment appointment)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
            }

            // Read
            public Appointment GetAppointmentById(int id)
            {
                return _context.Appointments
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor)
                    .SingleOrDefault(a => a.ID == id);
            }

            // Update
            public void UpdateAppointment(Appointment appointment)
            {
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
            }

            // Delete
            public void DeleteAppointment(int id)
            {
                var appointment = _context.Appointments.Find(id);
                if (appointment != null)
                {
                    _context.Appointments.Remove(appointment);
                    _context.SaveChanges();
                }
            }
        }

    }
}
