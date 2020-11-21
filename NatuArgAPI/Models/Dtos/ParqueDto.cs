using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Models.Dtos
{
    public class ParqueDto: LugarDto
    {
        [Required]
        public string Provincia { get; set; }
    }
}
