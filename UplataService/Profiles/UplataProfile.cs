using System;
using AutoMapper;
using UplataService.DtoModels;
using UplataService.Entities.cs;

namespace UplataService.Profiles
{
	public class UplataProfile : Profile
	{
		public UplataProfile()
		{
			CreateMap<Uplata, UplataDto>();
			CreateMap<UplataDto, Uplata>();
			CreateMap<UplataUpdateDto, Uplata>();
            CreateMap<UplataCreateDto, Uplata>();
            CreateMap<UplataUpdateDto, UplataDto>();

        }
	}
}

