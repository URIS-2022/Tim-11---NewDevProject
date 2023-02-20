using System;
using System.Runtime.CompilerServices;
using AutoMapper;
using Dokument.Entities;
using Dokument.Repositories;
using Dokument.DtoModels;

namespace Dokument.Services
{
    public class DokumentService
    {
        public static List<Entities.Dokument> dokument { get; set; } = new List<Entities.Dokument>();

        private readonly DokumentContext dokumentContext;
        private readonly IMapper mapper;

        public DokumentService(DokumentContext dokumentContext, IMapper mapper)
        {
            this.dokumentContext = dokumentContext;
            this.mapper = mapper;
        }



        public void deleteDokument(Guid id)
        {
            Entities.Dokument dok = getDokumentByID(id);
            dokument.Remove(dok);


        }
        public List<Entities.Dokument> getDokument()
        {
            return dokumentContext.Dokument.ToList();
        }

        public Entities.Dokument getDokumentByID(Guid id)
        {
            return dokument.FirstOrDefault(dok => dok.DokumentId == id);
        }

        public DokumentConfirmationDto postDokument(Entities.Dokument dok)
        {
            dok.DokumentId = Guid.NewGuid();

            return mapper.Map<DokumentConfirmationDto>(dok);
        }

        public bool SaveChanges()
        {
            return true;
        }

        public DokumentConfirmationDto updateDokument(Entities.Dokument dok)
        {
            throw new NotImplementedException();
        }


    }
}
