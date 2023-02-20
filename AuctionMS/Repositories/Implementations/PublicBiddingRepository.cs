using AuctionMS.Communication;
using AuctionMS.Entities;
using AuctionMS.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AuctionMS.Repositories.Implementations
{
    public class PublicBiddingRepository : IPublicBiddingRepository
    {
        private readonly PublicBiddingContext _PublicBiddingContext;

        public PublicBiddingRepository(PublicBiddingContext bidingContext)
        {
            _PublicBiddingContext = bidingContext;
        }

        public async Task<PublicBidding> Create(CreatePublicBiddingDto createPublicBiddingDto)
        {
            PublicBidding publicBidding = new PublicBidding
            {
                PublicBiddingUID = Guid.NewGuid(),
                BeginTime = createPublicBiddingDto.BeginTime,
                BidPrice = createPublicBiddingDto.BidPrice,
                Date = createPublicBiddingDto.Date,
                EndTime = createPublicBiddingDto.EndDate,
                LeasePeriod = createPublicBiddingDto.LeasePeriod,
                NumberOfContestants = createPublicBiddingDto.NumberOfContestants,
                Status = createPublicBiddingDto.Status
            };

            var newPublicBidding = await _PublicBiddingContext.AddAsync(publicBidding);

            await _PublicBiddingContext.SaveChangesAsync();

            LoggerProvider.PublishLogMessage($"New public bidding with uid {publicBidding.PublicBiddingUID} entity added");

            return newPublicBidding.Entity;
        }

        public async Task DeleteByUid(Guid uid)
        {
            var biddingToRemove = await GetByUid(uid);

            LoggerProvider.PublishLogMessage($"Public bidding with uid {uid} deleted");

            _PublicBiddingContext.Remove(biddingToRemove);
        }

        public async Task<IEnumerable<PublicBidding>> GetAll()
        {
            return await _PublicBiddingContext.PublicBiddings?.ToListAsync();
        }

        public async Task<PublicBidding> GetByUid(Guid uid)
        {
            var publicBidding = await _PublicBiddingContext.PublicBiddings.FirstOrDefaultAsync((pb) => pb.PublicBiddingUID == uid);

            if (publicBidding == null)
            {
                LoggerProvider.PublishLogMessage($"Public bidding with uid {uid} not found");

                throw new EntityNotFoundException($"Public bidding with uid {uid} not found");
            }

            return publicBidding;
        }

        public async Task<PublicBidding> Update(Guid uid, UpdatePublicBiddingDto newPublicBidding)
        {
            var publicBidding = await GetByUid(uid);

            publicBidding.BeginTime = newPublicBidding.BeginTime;
            publicBidding.BidPrice = newPublicBidding.BidPrice;
            publicBidding.Date = newPublicBidding.Date;
            publicBidding.EndTime = newPublicBidding.EndDate;
            publicBidding.LeasePeriod = newPublicBidding.LeasePeriod;
            publicBidding.NumberOfContestants = newPublicBidding.NumberOfContestants;
            publicBidding.Status = newPublicBidding.Status;

            await _PublicBiddingContext.SaveChangesAsync();

            LoggerProvider.PublishLogMessage($"Public bidding with uid {uid} updated");

            return publicBidding;
        }
    }
}
