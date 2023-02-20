using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class OblikSvojineUpdateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti id oblika svojine")]
        public Guid OblikSvojineID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv oblika svojine")]
        public String OblikSvojineNaziv { get; set; }
    }
}
