using System;
using AuctionService.DtoModels;
using AuctionService.Entities;
using AuctionService.Repository;
using AutoMapper;

namespace AuctionService.Services
{
    public class LicitacijaService : ILicitacijaRepository
    {
        private readonly JavnoNadmetanjeContext context;
        private readonly IMapper mapper;
        public static List<Licitacija> licitacijas { get; set; } = new List<Licitacija>();

        public LicitacijaService(IMapper mapper, JavnoNadmetanjeContext context)
        {
            this.context = context;
            this.mapper = mapper;
            
        }

        public void deleteLicitacija(Guid id)
        {
            Entities.Licitacija licitacija = getLicitacijaById(id);
            context.licitacije.Add(licitacija);
            
        }

        public List<Licitacija> getAllLicitacija()
        {
            return context.licitacije.ToList();
          
        }

        public Licitacija getLicitacijaById(Guid id)
        {
            return context.licitacije.FirstOrDefault(licitacija => licitacija.licitacijaID == id);
            
        }

        public LicitacijaConformationDto postLicitacija(Licitacija licitacija)
        {
            licitacija.licitacijaID = Guid.NewGuid();
            var novaLicitacija = context.licitacije.Add(licitacija);
            return mapper.Map<LicitacijaConformationDto>(novaLicitacija.Entity);
           
        }

        public bool saveChanges()
        {
            return context.SaveChanges() > 1;
        }

        public LicitacijaConformationDto updateLicitacija(Licitacija licitacija)
        {
            throw new NotImplementedException();
        }
    }
}

