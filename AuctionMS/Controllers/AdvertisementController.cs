using AuctionMS.Entities;
using AuctionMS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuctionMS.Controllers
{
    [ApiController]
    [Route("advertisement")]
    public class AdvertisementController : ControllerBase
    {
        
            private IAdvertisementRepository _advertisementRepository;

            public AdvertisementController(IAdvertisementRepository advertisementRepository)
            {
                _advertisementRepository = advertisementRepository;
            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<IEnumerable<Advertisement>> GetAll()
            {
                return await _advertisementRepository.GetAll();
            }

            [HttpGet("{advertisementUid}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<Advertisement> GetByUid(Guid advertisementUid)
            {
                return await _advertisementRepository.GetByUid(advertisementUid);
            }

            [HttpPatch("{advertisementUid}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<Advertisement> Update(Guid advertisementUid, [FromBody] UpdateAdvertisementDto requestDto)
            {
                return await _advertisementRepository.Update(advertisementUid, requestDto);
            }

            [HttpDelete("{advertisementUid}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task Delete(Guid advertisementUid)
            {
                await _advertisementRepository.DeleteByUid(advertisementUid);
            }

            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            public async Task<Advertisement> CreatePublicBidding([FromBody] CreateAdvertisementDto requestDto)
            {
                return await _advertisementRepository.Create(requestDto);
            }
        }
    }

