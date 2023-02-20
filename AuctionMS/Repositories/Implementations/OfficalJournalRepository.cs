using AuctionMS.Communication;
using AuctionMS.Entities;
using AuctionMS.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AuctionMS.Repositories.Implementations
{
    public class OfficalJournalRepository: IOfficialJournalRepository
    {
        private readonly PublicBiddingContext _officialJournalContext;

        public OfficalJournalRepository(PublicBiddingContext officialJournalContext)
        {
            _officialJournalContext = officialJournalContext;
        }

        public async Task<OfficialJournal> Create(CreateOfficialJournalDto createOfficialJournalDto)
        {
            OfficialJournal officialJournal = new OfficialJournal
            {
                OfficialJournalUID = Guid.NewGuid(),
                DateOfIssue = createOfficialJournalDto.DateOfIssue,
                Municipality = createOfficialJournalDto.Municipality,

            };

            var newOfficialJournal = await _officialJournalContext.AddAsync(officialJournal);

            await _officialJournalContext.SaveChangesAsync();

            LoggerProvider.PublishLogMessage($"New Official Journal with uid {officialJournal.OfficialJournalUID} entity added");

            return newOfficialJournal.Entity;
        }

        public async Task DeleteByUid(Guid uid)
        {
            var officialJournalToRemove = await GetByUid(uid);

            LoggerProvider.PublishLogMessage($"Official Journal with uid {uid} deleted");

            _officialJournalContext.Remove(officialJournalToRemove);
        }

        public async Task<IEnumerable<OfficialJournal>> GetAll()
        {
            return await _officialJournalContext.OfficialJournals?.ToListAsync();
        }

        public async Task<OfficialJournal> GetByUid(Guid uid)
        {
            var officialJournal = await _officialJournalContext.OfficialJournals.FirstOrDefaultAsync((of) => of.OfficialJournalUID == uid);

            if (officialJournal == null)
            {
                LoggerProvider.PublishLogMessage($"Official Journal with uid {uid} not found");

                throw new EntityNotFoundException($"Official Journal with uid {uid} not found");
            }

            return officialJournal;
        }

        public async Task<OfficialJournal> Update(Guid uid, UpdateOfficialJournalDto newOfficialJournal)
        {
            var officialJournal = await GetByUid(uid);

            officialJournal.DateOfIssue = newOfficialJournal.DateOfIssue;
            officialJournal.Municipality = newOfficialJournal.Municipality;

            await _officialJournalContext.SaveChangesAsync();

            LoggerProvider.PublishLogMessage($"Official Journal with uid {uid} updated");

            return officialJournal;
        }
    }
}
