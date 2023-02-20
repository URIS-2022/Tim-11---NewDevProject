using System;
using AuctionService.DtoModels;
using AutoMapper;

namespace AuctionService.Profiles
{
	public class LicitacijaProfile : Profile
	{
		public LicitacijaProfile()
		{
            CreateMap<Entities.Licitacija, LicitacijaDto>();
            CreateMap<LicitacijaDto, LicitacijaDto>();
            CreateMap<LicitacijaDto, Entities.Licitacija>();
            CreateMap<LicitacijaDto, LicitacijaConformationDto>();
            CreateMap<Entities.Licitacija, LicitacijaConformationDto>();
            CreateMap<LicitacijaConformationDto, LicitacijaConformationDto>();
            CreateMap<LicitacijaCreationDto, Entities.Licitacija>();
            CreateMap<LicitacijaUpdateDto, Entities.Licitacija>();
        }
	}
}

