using AuctionMS.Entities;

namespace AuctionMS.Repositories
{
    public interface IOfficialJournalRepository
    {
        public Task<IEnumerable<OfficialJournal>> GetAll();

        public Task<OfficialJournal> GetByUid(Guid uid);

        public Task DeleteByUid(Guid uid);

        public Task<OfficialJournal> Update(Guid uid, UpdateOfficialJournalDto newOfficialJournal);

        public Task<OfficialJournal> Create(CreateOfficialJournalDto createOfficialJournalDto);
    }
}
