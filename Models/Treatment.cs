using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Models
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public DateTime TreatmentDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string TreatmentType { get; set; }
        
        public string Outcome { get; set; }
    }
}
