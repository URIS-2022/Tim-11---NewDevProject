using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.DtoModels
{
	public class LicitacijaCreationDto
	{
        /// <summary>
        /// Broj licitacije
        /// </summary>
        /// 
        [Required(ErrorMessage = "Obavezno je uneti broj licitacije")]
        public int broj { get; set; }

        /// <summary>
        /// Godina licitacije
        /// </summary>
        /// 
        public int godina { get; set; }

        /// <summary>
        /// Datum licitacije
        /// </summary>
        /// 
        public DateTime datum { get; set; }

        /// <summary>
        /// Ogranicenja licitacije
        /// </summary>
        /// 
        public int ogranicenja { get; set; }

        /// <summary>
        /// Korak cene licitacije
        /// </summary>
        /// 
        public int korakCene { get; set; }

        /// <summary>
        /// Id javnog nadmetanja
        /// </summary>
        /// 
       
        public Guid javnoNadmetanjeId { get; set; }

        /// <summary>
        /// Rok za dostavu prijave na licitaciju
        /// </summary>
        /// 
        public DateTime rokZaDostavljanje { get; set; }
    }
}

