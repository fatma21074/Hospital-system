using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Models
{
    public class Doctor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Specialization { get; set; }
        [MaxLength(10)]
        public int YearsOfExperience { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public string DoctorName { get; internal set; }
        public int PatientCount { get; internal set; }
    }
}
