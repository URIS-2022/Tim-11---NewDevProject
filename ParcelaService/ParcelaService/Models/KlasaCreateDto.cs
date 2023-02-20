using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class KlasaCreateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti oznaku klase")]
        public String KlasaOznaka { get; set; }
    }
}
