using System.ComponentModel.DataAnnotations;

namespace AuctionMS.Entities
{
    /// <summary>
    /// Public bidding entity
    /// </summary>
    /// 
    public class PublicBidding
    {

        /// <summary>
        /// Public Bidding ID
        /// </summary>
        public Guid PublicBiddingUID { get; set; } = Guid.NewGuid();

        public int PublicBiddingID { get; set; }

        /// <summary>
        /// Date of Public Bidding
        ///</summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Start time of the Bidding
        /// </summary>
        public DateTime BeginTime { get; set; } 

        /// <summary>
        /// End time of the Bidding
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Starting bidding price
        /// </summary>
        public double BidPrice { get; set; }    

        /// <summary>
        /// Number of Contestants
        /// </summary>
        public int NumberOfContestants { get; set; }    

        /// <summary>
        /// Lease period
        /// </summary>
        public int LeasePeriod { get; set; }    


        /// <summary>
        /// Status of Bidding
        /// </summary>
        public string Status { get; set; } 




        
    }
}
