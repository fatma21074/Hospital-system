using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Models
{
    public class MedicalRecord
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Diagnosis { get; set; }
        public string PrescribedTreatments { get; set; }
        public string Notes { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<Treatment> Treatments { get; set; }
    }
}
