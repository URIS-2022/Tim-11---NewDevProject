using System;
using KorisnikService.Entities.cs;

namespace KorisnikService.Repositories
{
	public interface IKorisnikRepository
	{
		List<Korisnik> getAllKorisnici();

		Korisnik getKorisnikById(Guid id);

		void deleteKorisnik(Guid id);

		Korisnik postKorisnik(Korisnik korisnik);

		void updateKorisnik(Korisnik korisnik);

		bool SaveChanges();

		bool checkIfUserExist(string username, string password);
	}
}

