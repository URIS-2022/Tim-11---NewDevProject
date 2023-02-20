using System;
using AutoMapper;
using KorisnikService.Entities;
using KorisnikService.Entities.cs;
using KorisnikService.Repositories;

namespace KorisnikService.Service
{
    public class KorisnikService : IKorisnikRepository
    {
        private readonly KorisnikContext korisnikContext;
        private readonly IMapper mapper;
        public KorisnikService(KorisnikContext korisnikContext)
        {
            this.korisnikContext = korisnikContext;

        }
        public bool checkIfUserExist(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void deleteKorisnik(Guid id)
        {
            Korisnik korisnik = getKorisnikById(id);
            korisnikContext.Korisnik.Remove(korisnik);
        }

        public List<Korisnik> getAllKorisnici()
        {
            return korisnikContext.Korisnik.ToList();
        }

        public Korisnik getKorisnikById(Guid id)
        {
            return korisnikContext.Korisnik.FirstOrDefault(korisnik => korisnik.korisnikId == id);
        }

        public Korisnik postKorisnik(Korisnik korisnik)
        {
            korisnik.korisnikId = Guid.NewGuid();
            korisnikContext.Korisnik.Add(korisnik);
            return korisnik;
        }

        public bool SaveChanges()
        {

            return korisnikContext.SaveChanges() > 0;
        }

        public void updateKorisnik(Korisnik korisnik)
        {
            throw new NotImplementedException();
        }
    }
}