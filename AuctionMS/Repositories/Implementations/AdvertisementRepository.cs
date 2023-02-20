using AuctionMS.Communication;
using AuctionMS.Entities;
using AuctionMS.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AuctionMS.Repositories.Implementations
{
    public class AdvertisementRepository: IAdvertisementRepository
    {
        private readonly PublicBiddingContext _PublicBiddingContext;

        public AdvertisementRepository(PublicBiddingContext advertContext)
        {
            _PublicBiddingContext = advertContext;
        }

        public async Task<Advertisement> Create(CreateAdvertisementDto createAdvertisementDto)
        {
            Advertisement advertisement = new Advertisement
            {
                AdvertisementUID = Guid.NewGuid(),
                DateOfAnnouncement = createAdvertisementDto.DateOfAnnouncement,
                Description = createAdvertisementDto.Description,
                
            };

            var newAdvertisement = await _PublicBiddingContext.AddAsync(advertisement);

            await _PublicBiddingContext.SaveChangesAsync();

            LoggerProvider.PublishLogMessage($"New Advertisement with uid {advertisement.AdvertisementUID} entity added");

            return newAdvertisement.Entity;
        }

        public async Task DeleteByUid(Guid uid)
        {
            var advertisementToRemove = await GetByUid(uid);

            LoggerProvider.PublishLogMessage($"Advertisement with uid {uid} deleted");

            _PublicBiddingContext.Remove(advertisementToRemove);
        }

        public async Task<IEnumerable<Advertisement>> GetAll()
        {
            return await _PublicBiddingContext.Advertisements?.ToListAsync();
        }

        public async Task<Advertisement> GetByUid(Guid uid)
        {
            var advertisement = await _PublicBiddingContext.Advertisements.FirstOrDefaultAsync((ad) => ad.AdvertisementUID == uid);

            if (advertisement == null)
            {
                LoggerProvider.PublishLogMessage($"Advertisement with uid {uid} not found");

                throw new EntityNotFoundException($"Advertisement with uid {uid} not found");
            }

            return advertisement;
        }

        public async Task<Advertisement> Update(Guid uid, UpdateAdvertisementDto newAdvertisement)
        {
            var advertisement = await GetByUid(uid);

            advertisement.DateOfAnnouncement = newAdvertisement.DateOfAnnouncement;
            advertisement.Description = newAdvertisement.Description;

            await _PublicBiddingContext.SaveChangesAsync();

            LoggerProvider.PublishLogMessage($"Public bidding with uid {uid} updated");

            return advertisement;
        }
    }
}
