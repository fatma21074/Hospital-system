using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataofBirth { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Appointment> Appointments { get; set; }


    }
}
