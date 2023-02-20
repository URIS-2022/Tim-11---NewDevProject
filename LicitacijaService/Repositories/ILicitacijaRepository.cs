using System;
using AuctionService.DtoModels;

namespace AuctionService.Repository
{
	public interface ILicitacijaRepository
	{
		List<Entities.Licitacija> getAllLicitacija();

		Entities.Licitacija getLicitacijaById(Guid id);

		void deleteLicitacija(Guid id);

		LicitacijaConformationDto postLicitacija(Entities.Licitacija licitacija);

		LicitacijaConformationDto updateLicitacija(Entities.Licitacija licitacija);

        bool saveChanges();

    }
}

