using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class OdvodnjavanjeUpdateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti id odvodnjavanja")]
        public Guid OdvodnjavanjeID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv odvodanjavanja")]
        public String OdvodnjavanjeNaziv { get; set; }
    }
}
