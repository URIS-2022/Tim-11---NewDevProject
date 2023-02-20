namespace AuctionMS.Entities
{
    public class UpdatePublicBiddingDto
    {
        public DateTime BeginTime { get; set; }
        public double BidPrice { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int LeasePeriod { get; set; }
        public int NumberOfContestants { get; set; }
    }
}
