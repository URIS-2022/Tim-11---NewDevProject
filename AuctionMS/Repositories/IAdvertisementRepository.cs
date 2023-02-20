using AuctionMS.Entities;

namespace AuctionMS.Repositories
{
    public interface IAdvertisementRepository
    {
        public Task<IEnumerable<Advertisement>> GetAll();

        public Task<Advertisement> GetByUid(Guid uid);

        public Task DeleteByUid(Guid uid);

        public Task<Advertisement> Update(Guid uid, UpdateAdvertisementDto newAdvertisement);

        public Task<Advertisement> Create(CreateAdvertisementDto createAdvertisementDto);
    }
}
