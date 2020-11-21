using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgWEB.Models
{
    public class Atraccion : Lugar
    {
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }

        [Required]
        public int ParqueId { get; set; }
        public Parque Parque { get; set; }
    }
}
