using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Models.Dtos
{
    public class ParqueDto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Provincia { get; set; }
        public string Imagen { get; set; }
    }
}
