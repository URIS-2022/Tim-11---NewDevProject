using System;
using UplataService.DtoModels;
using UplataService.Entities;
using UplataService.Entities.cs;
using UplataService.Repositories;

namespace UplataService.Service
{
    public class BankaService : IBankaRepository
    {
        private readonly UplataContext uplataContext;
        public BankaService(UplataContext uplataContext)
        {

            this.uplataContext = uplataContext;

        }
        public List<Banka> getAllBanke()
        {
            return uplataContext.Banka.ToList();
        }

        public Banka getBankaById(Guid id)
        {
            return uplataContext.Banka.FirstOrDefault(ban => ban.bankaId == id);
        }

        public void deleteBanka(Guid id)
        {
            Banka bk = getBankaById(id);
            uplataContext.Banka.Remove(bk);
        }

        public void updateBanka(Banka banka)
        {
            throw new NotImplementedException();
        }

        public Banka postBanka(Banka banka)
        {
            banka.bankaId = Guid.NewGuid();
            uplataContext.Banka.Add(banka);
            return banka;
        }

        public bool SaveChanges()
        {
            return uplataContext.SaveChanges() > 0;
        }


    }
}
