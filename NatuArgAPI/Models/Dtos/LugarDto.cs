using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Models.Dtos
{
    public abstract class LugarDto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}
