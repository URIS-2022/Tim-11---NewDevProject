using AutoMapper;

namespace Dokument.Profiles
{
    public class DokumentProfile:Profile
    {
        public DokumentProfile()
        {
            CreateMap<Entities.Dokument, DtoModels.DokumentDto>();
            CreateMap<DtoModels.DokumentDto, Entities.Dokument>();
            CreateMap<DtoModels.DokumentDto, DtoModels.DokumentConfirmationDto>();
            CreateMap<Entities.Dokument, DtoModels.DokumentConfirmationDto>();
            CreateMap<Entities.Dokument, DtoModels.DokumentConfirmationDto>();
            CreateMap<DtoModels.DokumentCreation, Entities.Dokument>();
            CreateMap<DtoModels.DokumentUpdateDto, Entities.Dokument>();


        }
    }
}
