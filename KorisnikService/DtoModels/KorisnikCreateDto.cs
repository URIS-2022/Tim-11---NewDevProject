using System;
namespace KorisnikService.DtoModels
{
	public class KorisnikCreateDto
	{
		public Guid tipKorisnikaId { get; set; }
		public string ime { get; set; }
		public string prezime { get; set; }
		public string korisnickoIme { get; set; }
		public string lozinka { get; set; }
	}
}

