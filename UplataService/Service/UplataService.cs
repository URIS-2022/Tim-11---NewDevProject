using System;
using AutoMapper;
using UplataService.Entities;
using UplataService.Entities.cs;
using UplataService.Repositories;

namespace UplataService.Service
{
    public class UplataService : IUplataRepository
    {
        private readonly UplataContext uplataContext;
        private readonly IMapper mapper;
        public UplataService(UplataContext uplataContext)
        {
            this.uplataContext = uplataContext;

        }
        public bool checkIfUserExist(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void deleteUplata(Guid id)
        {
            Uplata uplata = getUplataById(id);
            uplataContext.Uplata.Remove(uplata);
        }

        public List<Uplata> getAllUplate()
        {
            return uplataContext.Uplata.ToList();
        }

        public Uplata getUplataById(Guid id)
        {
            return uplataContext.Uplata.FirstOrDefault(uplata => uplata.uplataId == id);
        }

        public Uplata postUplata(Uplata uplata)
        {
            uplata.uplataId = Guid.NewGuid();
            uplataContext.Uplata.Add(uplata);
            return uplata;
        }

        public bool SaveChanges()
        {

            return uplataContext.SaveChanges() > 0;
        }

        public void updateUplata(Uplata uplata)
        {
            throw new NotImplementedException();
        }
    }
}