using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Models.Dtos
{
    public class AtraccionInsertDto: LugarDto
    {
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }

        [Required]
        public int ParqueId { get; set; }
    }
}
