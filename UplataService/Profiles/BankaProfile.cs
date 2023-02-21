using System;
using AutoMapper;
using UplataService.DtoModels;
using UplataService.Entities.cs;

namespace UplataService.Profiles
{
	public class BankaProfile : Profile
	{
		public BankaProfile()
		{
            CreateMap<Banka, BankaDto>();
            CreateMap<BankaDto, Banka>();
            CreateMap<BankaUpdateDto, Banka>();
            CreateMap<BankaUpdateDto, Banka>();
        }
	}
}

