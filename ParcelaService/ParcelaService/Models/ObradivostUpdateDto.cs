using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class ObradivostUpdateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti id obradivosti")]
        public Guid ObradivostID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv obradivosti")]
        public String ObradivostNaziv { get; set; }
    }
}