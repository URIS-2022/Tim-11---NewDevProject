using System;
using AutoMapper;
using KorisnikService.DtoModels;
using KorisnikService.Entities.cs;

namespace KorisnikService.Profiles
{
	public class TipKorisnikaProfile : Profile
	{
		public TipKorisnikaProfile()
		{
            CreateMap<TipKorisnika, TipKorisnikaDto>();
            CreateMap<TipKorisnikaDto, TipKorisnika>();
            CreateMap<TipKorisnikaUpdateDto, TipKorisnika>();
            CreateMap<TipKorisnikaUpdateDto, TipKorisnika>();
        }
	}
}

