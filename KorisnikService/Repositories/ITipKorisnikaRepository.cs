using System;
using KorisnikService.Entities.cs;

namespace KorisnikService.Repositories
{
	public interface ITipKorisnikaRepository
	{
		List<TipKorisnika> getAllTipoviKorisnika();

        TipKorisnika getTipKorisnikaById(Guid id);

		void deleteTipKorisnika(Guid id);

		void updateTipKorisnika(TipKorisnika tipKorisnika);

		TipKorisnika postTipKorisnika(TipKorisnika tipKorisnika);

		bool SaveChanges();

	}

}

