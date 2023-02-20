namespace Zalba.DtoModels
{
    public class ZalbaUpdate
    {
        public Guid ZalbaId { get; set; }

        public DateTime DatumPodnosenja { get; set; }

        public DateTime DatumResenja { get; set; }

        public string? Obrazlozenje { get; set; }
        public string? Status { get; set; }
    }
}
