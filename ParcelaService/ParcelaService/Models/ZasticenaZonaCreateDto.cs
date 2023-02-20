using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class ZasticenaZonaCreateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti oznaku zasticene zone")]
        public int ZasticenaZonaOznaka { get; set; }
    }
}