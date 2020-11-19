using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Models
{
    public class Parque
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Provincia { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
