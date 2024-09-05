using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_system.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
