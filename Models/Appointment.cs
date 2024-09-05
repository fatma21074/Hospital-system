using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Models
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; } //Navigation Property
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Purpose { get; set; }
        public bool IsConfirmed { get; set; }

    }
}
