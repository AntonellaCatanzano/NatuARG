using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgWEB.Models
{
    public abstract class Lugar
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}
