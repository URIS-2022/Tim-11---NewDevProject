using AuctionMS.Entities;
using AuctionMS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuctionMS.Controllers
{
    [ApiController]
    [Route("public-bidding")]
    public class PublicBiddingController : ControllerBase
    {
        private IPublicBiddingRepository _publicBiddingRepository;

        public PublicBiddingController(IPublicBiddingRepository publicBiddingRepository)
        {
            _publicBiddingRepository = publicBiddingRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PublicBidding>> GetAll()
        {
            return await _publicBiddingRepository.GetAll();
        }

        [HttpGet("{publicBiddingUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<PublicBidding> GetByUid(Guid publicBiddingUid)
        {
            return await _publicBiddingRepository.GetByUid(publicBiddingUid);
        }

        [HttpPatch("{publicBiddingUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<PublicBidding> Update(Guid publicBiddingUid, [FromBody] UpdatePublicBiddingDto requestDto)
        {
            return await _publicBiddingRepository.Update(publicBiddingUid, requestDto);
        }

        [HttpDelete("{publicBiddingUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task Delete(Guid publicBiddingUid)
        {
            await _publicBiddingRepository.DeleteByUid(publicBiddingUid);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<PublicBidding> CreatePublicBidding([FromBody] CreatePublicBiddingDto requestDto)
        {
            return await _publicBiddingRepository.Create(requestDto);
        }
    }
}
