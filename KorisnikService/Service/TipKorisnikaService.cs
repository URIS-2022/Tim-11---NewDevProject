using System;
using KorisnikService.DtoModels;
using KorisnikService.Entities;
using KorisnikService.Entities.cs;
using KorisnikService.Repositories;

namespace KorisnikService.Service
{
    public class TipKorisnikaService : ITipKorisnikaRepository
    {
        private readonly KorisnikContext korisnikContext;
        public TipKorisnikaService(KorisnikContext korisnikContext)
        {

            this.korisnikContext = korisnikContext;

        }
        public List<TipKorisnika> getAllTipoviKorisnika()
        {
            return korisnikContext.TipKorisnika.ToList();
        }

        public TipKorisnika getTipKorisnikaById(Guid id)
        {
            return korisnikContext.TipKorisnika.FirstOrDefault(tip => tip.tipKorisnikaId == id);
        }

        public void deleteTipKorisnika(Guid id)
        {
            TipKorisnika tk = getTipKorisnikaById(id);
            korisnikContext.TipKorisnika.Remove(tk);
        }

        public void updateTipKorisnika(TipKorisnika tipKorisnika)
        {
            throw new NotImplementedException();
        }

        public TipKorisnika postTipKorisnika(TipKorisnika tipKorisnika)
        {
            tipKorisnika.tipKorisnikaId = Guid.NewGuid();
            korisnikContext.TipKorisnika.Add(tipKorisnika);
            return tipKorisnika;
        }

        public bool SaveChanges()
        {
            return korisnikContext.SaveChanges() > 0;
        }


    }
}
