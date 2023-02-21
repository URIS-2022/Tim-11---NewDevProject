using System;
namespace UplataService.DtoModels
{
	public class UplataUpdateDto
    {
        public Guid uplataId { get; set; }
        public Guid bankaId { get; set; }
        public string datumUplate { get; set; }
        public string svrhaUplate { get; set; }
        public int iznos { get; set; }
        public string brojRacuna { get; set; }
    }
}

