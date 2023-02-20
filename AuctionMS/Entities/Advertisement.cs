using System.ComponentModel.DataAnnotations;

namespace AuctionMS.Entities
{
    public class Advertisement
    {
        /// <summary>
        /// Adverterisement ID
        /// </summary>
        [Key]
        public Guid AdvertisementUID { get; set; } = Guid.NewGuid();
        
        public int AdvertisementID { get; set; }

        /// <summary> 
        /// Date of Announcement
        /// </summary>
        public DateTime DateOfAnnouncement { get; set; }  
        
        /// <summary>
        /// Description of the advertisement
        /// </summary>
        public string? Description { get; set; }    


        public PublicBidding _PublicBidding { get; set; }

        public int PublicBiddingFK { get; set; }
    }
}
