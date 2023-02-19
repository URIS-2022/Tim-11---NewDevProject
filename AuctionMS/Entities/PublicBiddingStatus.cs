namespace AuctionMS.Entities
{
    public static class PublicBiddingStatus
    {
        public const string FirstRound = "FirstRound";
        public const string SecondRoundWithOldConditions = "SecondRoundWithOldConditions";
        public const string SecondRoundWithNewConditions = "SecondRoundWithNewConditions";

        public static string Create(string value)
        {
            switch (value)
            {
                case FirstRound:
                case SecondRoundWithOldConditions:
                case SecondRoundWithNewConditions:
                    return value;
                default:
                    throw new InvalidDataException();
            }
        }
    }
}
