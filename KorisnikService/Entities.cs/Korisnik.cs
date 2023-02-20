using System;
namespace KorisnikService.Entities.cs
{
	public class Korisnik
	{
		public Guid korisnikId { get; set; }
		public Guid tipKorisnikaId { get; set; }
		public string ime { get; set; }
		public string prezime { get; set; }
		public string korisnickoIme { get; set; }
		public string lozinka { get; set; }
	}
}

