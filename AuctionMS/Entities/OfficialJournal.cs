using System.ComponentModel.DataAnnotations;

namespace AuctionMS.Entities
{
    public class OfficialJournal
    {
        /// <summary>
        /// Official Journal ID
        /// </summary>
        [Key]
        public Guid OfficialJournalUID { get; set; } = Guid.NewGuid();

        public int OfficialJournalID { get; set; }

        /// <summary>
        /// Municipality
        /// </summary>
        public string? Municipality { get; set; }    

        /// <summary>
        /// Date Of Issue
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        public Advertisement _Advertisement { get; set; }

        public int AdvertisementFk { get; set; }
    }
}
