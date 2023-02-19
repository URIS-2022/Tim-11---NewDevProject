using Microsoft.EntityFrameworkCore;

namespace AuctionMS.Entities
{
    public class PublicBiddingContext: DbContext
    {
        private readonly IConfiguration Configuration;

        public PublicBiddingContext(IConfiguration configuration, DbContextOptions<PublicBiddingContext> options) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<PublicBidding> PublicBiddings { get; set; }
        public DbSet<OfficialJournal> OfficialJournals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // define the connections between entities

            #region Public bidding

            modelBuilder.Entity<PublicBidding>()
                        .HasKey((pb) => pb.PublicBiddingID);

            modelBuilder.Entity<PublicBidding>()
                        .Property(pb => pb.PublicBiddingID)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<PublicBidding>()
                        .Property((pb) => pb.BeginTime)
                        .IsRequired();

            modelBuilder.Entity<PublicBidding>()
                        .Property((pb) => pb.EndTime)
                        .IsRequired();

            modelBuilder.Entity<PublicBidding>()
                        .Property((pb) => pb.Date)
                        .IsRequired();

            modelBuilder.Entity<PublicBidding>()
                        .Property((pb) => pb.BidPrice)
                        .IsRequired();

            modelBuilder.Entity<PublicBidding>()
                        .Property((pb) => pb.NumberOfContestants)
                        .IsRequired();

            modelBuilder.Entity<PublicBidding>()
                        .Property((pb) => pb.LeasePeriod)
                        .IsRequired();

            modelBuilder.Entity<PublicBidding>()
                        .Property((pb) => pb.Status)
                        .IsRequired();

            modelBuilder.Entity<PublicBidding>()
                        .Property((pb) => pb.PublicBiddingUID)
                        .IsRequired();

            #endregion

            #region Advertisement

            modelBuilder.Entity<Advertisement>()
                        .HasKey((ad) => ad.AdvertisementID);

            modelBuilder.Entity<Advertisement>()
                        .Property(ad => ad.AdvertisementID)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Advertisement>()
                        .Property((ad) => ad.DateOfAnnouncement)
                        .IsRequired();

            modelBuilder.Entity<Advertisement>()
                        .Property((ad) => ad.Description)
                        .IsRequired();

            modelBuilder.Entity<Advertisement>()
                        .Property((ad) => ad.AdvertisementUID)
                        .IsRequired();

            #endregion

            #region Official journal

            modelBuilder.Entity<OfficialJournal>()
                        .HasKey((oj) => oj.OfficialJournalID);

            modelBuilder.Entity<OfficialJournal>()
                        .Property(oj => oj.OfficialJournalID)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<OfficialJournal>()
                        .Property(oj => oj.DateOfIssue)
                        .IsRequired();

            modelBuilder.Entity<OfficialJournal>()
                        .Property(oj => oj.Municipality)
                        .IsRequired();

            modelBuilder.Entity<OfficialJournal>()
                        .Property(oj => oj.OfficialJournalUID)
                        .IsRequired();

            #endregion

            #region Foreign keys

            modelBuilder.Entity<Advertisement>()
                        .HasOne(a => a._PublicBidding)
                        .WithMany()
                        .HasForeignKey("PublicBiddingFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

            modelBuilder.Entity<OfficialJournal>()
                       .HasOne(a => a._Advertisement)
                       .WithMany()
                       .HasForeignKey("AdvertisementFk")
                       .OnDelete(DeleteBehavior.Cascade)
                       .IsRequired();

            #endregion

            // seed 
            modelBuilder.Entity<PublicBidding>()
                        .HasData(new PublicBidding
                        {
                            BeginTime = DateTime.UtcNow,
                            BidPrice = 150,
                            Date = DateTime.UtcNow,
                            EndTime = DateTime.UtcNow,
                            LeasePeriod = 12,
                            NumberOfContestants = 5,
                            PublicBiddingUID = Guid.NewGuid(),
                            PublicBiddingID = 1,
                            Status = PublicBiddingStatus.FirstRound
                        });

            modelBuilder.Entity<Advertisement>().HasData(new Advertisement
            {
                AdvertisementUID= Guid.NewGuid(),
                AdvertisementID = 1,
                DateOfAnnouncement = DateTime.UtcNow,
                Description= "test",
                PublicBiddingFK= 1

            });

            modelBuilder.Entity<OfficialJournal>().HasData(new OfficialJournal
            {
                OfficialJournalUID = Guid.NewGuid(),
                OfficialJournalID = 1,
                Municipality = "Novi Sad",
                DateOfIssue= DateTime.UtcNow,
                AdvertisementFk= 1

            });
                    
        }
    }
}

