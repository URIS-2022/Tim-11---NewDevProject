using AuctionMS.Entities;

namespace AuctionMS.Repositories
{
    public interface IPublicBiddingRepository
    {
        public Task<IEnumerable<PublicBidding>> GetAll();

        public Task<PublicBidding> GetByUid(Guid uid);

        public Task DeleteByUid(Guid uid);

        public Task<PublicBidding> Update(Guid uid, UpdatePublicBiddingDto newPublicBidding);

        public Task<PublicBidding> Create(CreatePublicBiddingDto createPublicBiddingDto);
    }
}
