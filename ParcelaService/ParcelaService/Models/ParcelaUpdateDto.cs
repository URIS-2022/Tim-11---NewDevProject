using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class ParcelaUpdateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti id parcele")]
        public Guid ParcelaID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti povrsinu parcele")]
        public int Povrsina { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti broj parcele")]
        public String BrojParcele { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti broj lista neporetnosti")]
        public String BrojListaNepokretnosti { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje kulture")]
        public String KulturaStvarnoStanje { get; set; }

        [Required(ErrorMessage = "Obavezno je stvarno stanje klase")]
        public String KlasaStvarnoStanje { get; set; }

        [Required(ErrorMessage = "Obavezno je stvarno stanje obradivosti")]
        public String ObradivostStvarnoStanje { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje zasticene zone")]
        public String ZasticenaZonaStvarnoStanje { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti stvarno stanje odvodnjavanja")]
        public String OdvodnjavanjeStvarnoStanje { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id zasticene zone")]
        public Guid ZasticenaZonaID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id odvodnjavanja")]
        public Guid OdvodnjavanjeID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id obradivosti")]
        public Guid ObradivostID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id oblika svojine")]
        public Guid OblikSvojineID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id kulture")]
        public Guid KulturaID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id klase")]
        public Guid KlasaID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id katastarske opstine")]
        public Guid KatastarskaOpstinaID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id kupca")]
        public Guid KupacID { get; set; }
    }
}
