using AuctionMS.Entities;
using AuctionMS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuctionMS.Controllers
{
    [ApiController]
    [Route("official-journal")]
    public class OfficialJournalController : ControllerBase
    {
        private IOfficialJournalRepository _officialJournalRepository;

        public OfficialJournalController(IOfficialJournalRepository officialJournalRepository)
        {
            _officialJournalRepository = officialJournalRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<OfficialJournal>> GetAll()
        {
            return await _officialJournalRepository.GetAll();
        }

        [HttpGet("{officialJournalUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<OfficialJournal> GetByUid(Guid officialJournalUid)
        {
            return await _officialJournalRepository.GetByUid(officialJournalUid);
        }

        [HttpPatch("{officialJornalUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<OfficialJournal> Update(Guid officialJournalUid, [FromBody] UpdateOfficialJournalDto requestDto)
        {
            return await _officialJournalRepository.Update(officialJournalUid, requestDto);
        }

        [HttpDelete("{officialJournalUid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task Delete(Guid officialJournalUid)
        {
            await _officialJournalRepository.DeleteByUid(officialJournalUid);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<OfficialJournal> CreatePublicBidding([FromBody] CreateOfficialJournalDto requestDto)
        {
            return await _officialJournalRepository.Create(requestDto);
        }
    }
}

