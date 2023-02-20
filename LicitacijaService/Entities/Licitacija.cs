using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities
{
	public class Licitacija
	{
        /// <summary>
        /// Licitacija id
        /// </summary>
        /// 
        [Key]
		public Guid licitacijaID { get; set; }

        /// <summary>
        /// Broj licitacije
        /// </summary>
        /// 
        public int broj { get; set; }

        /// <summary>
        /// Godina odrzavanja licitacije
        /// </summary>
        /// 
        public int godina { get; set; }

        /// <summary>
        /// Datum licitacija
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
        /// Lista dokumentacije koju podnose fizicka lica
        /// </summary>
        /// 
        [NotMapped]
        public List<string> listaDokumentacijeFizickaLica { get; set; }

        /// <summary>
        /// Lista dokumentacije koju podnose pravna lica
        /// </summary>
        /// 
        [NotMapped]
        public List<string> listaDokumentacijePravnaLica { get; set; }


        /// <summary>
        /// Id javnog nadmetanja
        /// </summary>
        /// 
		[ForeignKey("javnoNadmetanje")]
		public Guid javnoNadmetanjeId{ get; set; }
		//public JavnoNadmetanje javnoNadmetanje { get; set; }

        /// <summary>
        /// Rok za dostavljanje dokumentacije
        /// </summary>
        /// 
		public DateTime rokZaDostavljanje { get; set; }

	}
}

