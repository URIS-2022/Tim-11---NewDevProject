using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Parcela.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcela.Models;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Parcela.Entities;
using Parcela.ServiceCals;
using System.Net;

namespace Parcela.Controllers
{

    [ApiController]
    [Route("api/parcele")]
    [Produces("application/json", "application/xml")]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaRepository parcelaRepository;
        private readonly IKatastarskaOpstinaService katastarskaOpstinaService;
        private readonly IKupacService kupacService;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IKorisnikSistemaService korisnikSistemaService;
        private readonly ILoggerService loggerService;
        private readonly LogDto logDto;

        public ParcelaController(IParcelaRepository parcelaRepository, LinkGenerator linkGenerator, IMapper mapper, IKorisnikSistemaService korisnikSistemaService, IKatastarskaOpstinaService katastarskaOpstinaService, IKupacService kupacService, ILoggerService loggerService)
        {
            this.parcelaRepository = parcelaRepository;
            this.katastarskaOpstinaService = katastarskaOpstinaService;
            this.kupacService = kupacService;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.korisnikSistemaService = korisnikSistemaService;
            this.loggerService = loggerService;
            logDto = new LogDto();
            logDto.NameOfTheService = "Parcela";
        }


      
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ParcelaDto>> GetParcele([FromServices] IKlasaRepository klasaRepository, [FromServices] IKulturaRepository kulturaRepository, [FromServices] IOblikSvojineRepository oblikSvojineRepository, [FromServices] IObradivostRepository obradivostRepository, [FromServices] IOdvodnjavanjeRepository odvodnjavanjeRepository, [FromServices] IZasticenaZonaRepository zasticenaZonaRepository)
        {
            string token = Request.Headers["token"].ToString();
            string[] split = token.Split('#');
            if (token == "" || (split[1] != "administrator" && split[1] != "superuser" && split[1] != "menadzer"))
            {
                return Unauthorized();
            }

            HttpStatusCode res = korisnikSistemaService.AuthorizeAsync(token).Result;
            if (res.ToString() != "OK")
            {
                return Unauthorized();
            }

            logDto.HttpMethod = "GET";
            logDto.Message = "Vracanje svih parcela";

            List<ParcelaEntity> parcele = parcelaRepository.GetParcele();
            if (parcele == null || parcele.Count == 0)
            {
                logDto.Level = "Warn";
                loggerService.CreateLog(logDto);
                return NoContent();
            }
            List<ParcelaDto> parceleDto = new List<ParcelaDto>();
            foreach(ParcelaEntity p in parcele)
            {
                ParcelaDto parcelaDto = mapper.Map<ParcelaDto>(p);
                parcelaDto.Klasa = mapper.Map<KlasaDto>(klasaRepository.GetKlasaById(p.KlasaID));
                parcelaDto.Kultura = mapper.Map<KulturaDto>(kulturaRepository.GetKulturaById(p.KulturaID));
                parcelaDto.OblikSvojine = mapper.Map<OblikSvojineDto>(oblikSvojineRepository.GetOblikSvojineById(p.OblikSvojineID));
                parcelaDto.Obradivost = mapper.Map<ObradivostDto>(obradivostRepository.GetObradivostById(p.ObradivostID));
                parcelaDto.Odvodnjavanje = mapper.Map<OdvodnjavanjeDto>(odvodnjavanjeRepository.GetOdvodnjavanjeById(p.OdvodnjavanjeID));
                parcelaDto.ZasticenaZona = mapper.Map<ZasticenaZonaDto>(zasticenaZonaRepository.GetZasticenaZonaById(p.ZasticenaZonaID));
                parcelaDto.Kupac = kupacService.GetKupacByIdAsync(p.KupacID, token).Result;
                parcelaDto.Opstina = katastarskaOpstinaService.GetKatastarskaOpstinaByIdAsync(p.KatastarskaOpstinaID, token).Result;
                parceleDto.Add(parcelaDto);
            }
        
            logDto.Level = "Info";
            loggerService.CreateLog(logDto);
            return Ok(parceleDto);
        }
     
      
        [HttpGet("{parcelaID}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ParcelaDto> GetParcela(Guid parcelaID, [FromServices] IKlasaRepository klasaRepository, [FromServices] IKulturaRepository kulturaRepository, [FromServices] IOblikSvojineRepository oblikSvojineRepository, [FromServices] IObradivostRepository obradivostRepository, [FromServices] IOdvodnjavanjeRepository odvodnjavanjeRepository, [FromServices] IZasticenaZonaRepository zasticenaZonaRepository)
        {
            string token = Request.Headers["token"].ToString();
            string[] split = token.Split('#');
            if (token == "" || (split[1] != "administrator" && split[1] != "superuser" && split[1] != "menadzer"))
            {
                return Unauthorized();
            }

            HttpStatusCode res = korisnikSistemaService.AuthorizeAsync(token).Result;
            if (res.ToString() != "OK")
            {
                return Unauthorized();
            }

            logDto.HttpMethod = "GET";
            logDto.Message = "Vracanje parcele po ID-ju";

            ParcelaEntity parcela = parcelaRepository.GetParcelaById(parcelaID);
            if(parcela == null)
            {
                logDto.Level = "Warn";
                loggerService.CreateLog(logDto);
                return NotFound();
            }
            ParcelaDto parcelaDto = mapper.Map<ParcelaDto>(parcela);
            parcelaDto.Klasa = mapper.Map<KlasaDto>(klasaRepository.GetKlasaById(parcela.KlasaID));
            parcelaDto.Kultura = mapper.Map<KulturaDto>(kulturaRepository.GetKulturaById(parcela.KulturaID));
            parcelaDto.OblikSvojine = mapper.Map<OblikSvojineDto>(oblikSvojineRepository.GetOblikSvojineById(parcela.OblikSvojineID));
            parcelaDto.Obradivost = mapper.Map<ObradivostDto>(obradivostRepository.GetObradivostById(parcela.ObradivostID));
            parcelaDto.Odvodnjavanje = mapper.Map<OdvodnjavanjeDto>(odvodnjavanjeRepository.GetOdvodnjavanjeById(parcela.OdvodnjavanjeID));
            parcelaDto.ZasticenaZona = mapper.Map<ZasticenaZonaDto>(zasticenaZonaRepository.GetZasticenaZonaById(parcela.ZasticenaZonaID));
            parcelaDto.Kupac = kupacService.GetKupacByIdAsync(parcela.KupacID, token).Result;
            parcelaDto.Opstina = katastarskaOpstinaService.GetKatastarskaOpstinaByIdAsync(parcela.KatastarskaOpstinaID, token).Result;
            logDto.Level = "Info";
            loggerService.CreateLog(logDto);
            return Ok(parcelaDto);
        }

     
        [HttpPost]
        [HttpHead]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaDto> CreateParcela([FromBody] ParcelaCreateDto parcela, [FromServices] IKlasaRepository klasaRepository, [FromServices] IKulturaRepository kulturaRepository, [FromServices] IOblikSvojineRepository oblikSvojineRepository, [FromServices] IObradivostRepository obradivostRepository, [FromServices] IOdvodnjavanjeRepository odvodnjavanjeRepository, [FromServices] IZasticenaZonaRepository zasticenaZonaRepository)
        {
            string token = Request.Headers["token"].ToString();
            string[] split = token.Split('#');
            if (token == "" || (split[1] != "administrator" && split[1] != "superuser"))
            {
                return Unauthorized();
            }

            HttpStatusCode res = korisnikSistemaService.AuthorizeAsync(token).Result;
            if (res.ToString() != "OK")
            {
                return Unauthorized();
            }

            logDto.HttpMethod = "POST";
            logDto.Message = "Dodavanje nove parcele";

            try
            {
                ParcelaEntity par = mapper.Map<ParcelaEntity>(parcela);
                ParcelaEntity p = parcelaRepository.CreateParcela(par);
                parcelaRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetParcela", "Parcela", new { parcelaID = p.ParcelaID });
                ParcelaDto parcelaDto = mapper.Map<ParcelaDto>(p);
                parcelaDto.Klasa = mapper.Map<KlasaDto>(klasaRepository.GetKlasaById(p.KlasaID));
                parcelaDto.Kultura = mapper.Map<KulturaDto>(kulturaRepository.GetKulturaById(p.KulturaID));
                parcelaDto.OblikSvojine = mapper.Map<OblikSvojineDto>(oblikSvojineRepository.GetOblikSvojineById(p.OblikSvojineID));
                parcelaDto.Obradivost = mapper.Map<ObradivostDto>(obradivostRepository.GetObradivostById(p.ObradivostID));
                parcelaDto.Odvodnjavanje = mapper.Map<OdvodnjavanjeDto>(odvodnjavanjeRepository.GetOdvodnjavanjeById(p.OdvodnjavanjeID));
                parcelaDto.ZasticenaZona = mapper.Map<ZasticenaZonaDto>(zasticenaZonaRepository.GetZasticenaZonaById(p.ZasticenaZonaID));
                parcelaDto.Kupac = kupacService.GetKupacByIdAsync(p.KupacID, token).Result;
                parcelaDto.Opstina = katastarskaOpstinaService.GetKatastarskaOpstinaByIdAsync(p.KatastarskaOpstinaID, token).Result;
                logDto.Level = "Info";
                loggerService.CreateLog(logDto);
                return Created(location, parcelaDto);
            }
            catch
            {
                logDto.Level = "Error";
                loggerService.CreateLog(logDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");            
            }
        }

        
        [HttpDelete("{parcelaID}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteParcela(Guid parcelaID)
        {
            string token = Request.Headers["token"].ToString();
            string[] split = token.Split('#');
            if (token == "" || (split[1] != "administrator" && split[1] != "superuser"))
            {
                return Unauthorized();
            }

            HttpStatusCode res = korisnikSistemaService.AuthorizeAsync(token).Result;
            if (res.ToString() != "OK")
            {
                return Unauthorized();
            }

            logDto.HttpMethod = "DELETE";
            logDto.Message = "Brisanje parcele";

            try
            {
                ParcelaEntity parcela = parcelaRepository.GetParcelaById(parcelaID);               
                if(parcela == null)
                {
                    logDto.Level = "Warn";
                    loggerService.CreateLog(logDto);
                    return NotFound();
                }
                parcelaRepository.DeleteParcela(parcelaID);
                parcelaRepository.SaveChanges();
                logDto.Level = "Info";
                loggerService.CreateLog(logDto);
                return NoContent();
            }
            catch
            {
                logDto.Level = "Error";
                loggerService.CreateLog(logDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

       
        [HttpPut]
        [HttpHead]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaDto> UpdateParcela(ParcelaUpdateDto parcela, [FromServices] IKlasaRepository klasaRepository, [FromServices] IKulturaRepository kulturaRepository, [FromServices] IOblikSvojineRepository oblikSvojineRepository, [FromServices] IObradivostRepository obradivostRepository, [FromServices] IOdvodnjavanjeRepository odvodnjavanjeRepository, [FromServices] IZasticenaZonaRepository zasticenaZonaRepository)
        {
            string token = Request.Headers["token"].ToString();
            string[] split = token.Split('#');
            if (token == "" || (split[1] != "administrator" && split[1] != "superuser"))
            {
                return Unauthorized();
            }

            HttpStatusCode res = korisnikSistemaService.AuthorizeAsync(token).Result;
            if (res.ToString() != "OK")
            {
                return Unauthorized();
            }

            logDto.HttpMethod = "PUT";
            logDto.Message = "Modifikacija parcele";

            try
            {
                ParcelaEntity oldParcela = parcelaRepository.GetParcelaById(parcela.ParcelaID);
                if (oldParcela == null)
                {
                    logDto.Level = "Warn";
                    loggerService.CreateLog(logDto);
                    return NotFound();
                }
                ParcelaEntity parcelaEntity = mapper.Map<ParcelaEntity>(parcela);

                oldParcela.Povrsina = parcelaEntity.Povrsina;
                oldParcela.BrojParcele = parcelaEntity.BrojParcele;
                oldParcela.BrojListaNepokretnosti = parcelaEntity.BrojListaNepokretnosti;
                oldParcela.KulturaStvarnoStanje = parcelaEntity.KulturaStvarnoStanje;
                oldParcela.KlasaStvarnoStanje = parcelaEntity.KlasaStvarnoStanje;
                oldParcela.ObradivostStvarnoStanje = parcelaEntity.ZasticenaZonaStvarnoStanje;
                oldParcela.OdvodnjavanjeStvarnoStanje = parcelaEntity.OdvodnjavanjeStvarnoStanje;
                oldParcela.ZasticenaZonaID = parcelaEntity.ZasticenaZonaID;
                oldParcela.OdvodnjavanjeID = parcelaEntity.OdvodnjavanjeID;
                oldParcela.ObradivostID = parcelaEntity.ObradivostID;
                oldParcela.OblikSvojineID = parcelaEntity.OblikSvojineID;
                oldParcela.KulturaID = parcelaEntity.KulturaID;
                oldParcela.KlasaID = parcelaEntity.KlasaID;
                oldParcela.KatastarskaOpstinaID = parcelaEntity.KatastarskaOpstinaID;
                oldParcela.KupacID = parcelaEntity.KupacID;

                parcelaRepository.SaveChanges();
                ParcelaDto parcelaDto = mapper.Map<ParcelaDto>(oldParcela);
                parcelaDto.Klasa = mapper.Map<KlasaDto>(klasaRepository.GetKlasaById(oldParcela.KlasaID));
                parcelaDto.Kultura = mapper.Map<KulturaDto>(kulturaRepository.GetKulturaById(oldParcela.KulturaID));
                parcelaDto.OblikSvojine = mapper.Map<OblikSvojineDto>(oblikSvojineRepository.GetOblikSvojineById(oldParcela.OblikSvojineID));
                parcelaDto.Obradivost = mapper.Map<ObradivostDto>(obradivostRepository.GetObradivostById(oldParcela.ObradivostID));
                parcelaDto.Odvodnjavanje = mapper.Map<OdvodnjavanjeDto>(odvodnjavanjeRepository.GetOdvodnjavanjeById(oldParcela.OdvodnjavanjeID));
                parcelaDto.ZasticenaZona = mapper.Map<ZasticenaZonaDto>(zasticenaZonaRepository.GetZasticenaZonaById(oldParcela.ZasticenaZonaID));
                parcelaDto.Kupac = kupacService.GetKupacByIdAsync(oldParcela.KupacID, token).Result;
                parcelaDto.Opstina = katastarskaOpstinaService.GetKatastarskaOpstinaByIdAsync(oldParcela.KatastarskaOpstinaID, token).Result;
                logDto.Level = "Info";
                loggerService.CreateLog(logDto);
                return Ok(parcelaDto);
            }
            catch (Exception)
            {
                logDto.Level = "Error";
                loggerService.CreateLog(logDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

        [HttpOptions]
        public IActionResult GetParcelaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            logDto.HttpMethod = "OPTIONS";
            logDto.Message = "Opcije za rad sa parcelama";
            logDto.Level = "Info";
            loggerService.CreateLog(logDto);
            return Ok();
        }
    }
}
