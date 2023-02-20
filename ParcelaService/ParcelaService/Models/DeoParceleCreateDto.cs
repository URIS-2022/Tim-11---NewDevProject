using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class DeoParceleCreateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti redni broj dela parcele")]
        public int RedniBroj { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti povrsinu dela parcele")]
        public int PovrsinaDelaParcele { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id parcele")]
        public Guid ParcelaID { get; set; }
    }
}