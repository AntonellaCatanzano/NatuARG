using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Models.Dtos
{
    public class AtraccionDto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public string Descripcion { get; set; }

        [Required]
        public int ParqueId { get; set; }
        public ParqueDto Parque { get; set; }
    }
}
