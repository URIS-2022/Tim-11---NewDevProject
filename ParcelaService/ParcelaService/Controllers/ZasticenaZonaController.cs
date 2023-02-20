﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Parcela.Data;
using Parcela.Entities;
using Parcela.Models;
using Parcela.ServiceCals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Parcela.Controllers
{

    [ApiController]
    [Route("api/zasticeneZone")]
    [Produces("application/json", "application/xml")]
    public class ZasticenaZonaController : ControllerBase
    {
        private readonly IZasticenaZonaRepository zasticenaZonaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IKorisnikSistemaService korisnikSistemaService;
        private readonly ILoggerService loggerService;
        private readonly LogDto logDto;

        public ZasticenaZonaController(IZasticenaZonaRepository zasticenaZonaRepository, LinkGenerator linkGenerator, IMapper mapper, IKorisnikSistemaService korisnikSistemaService, ILoggerService loggerService)
        {
            this.zasticenaZonaRepository = zasticenaZonaRepository;
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
        public ActionResult<List<ZasticenaZonaDto>> GetZasticeneZone()
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
            logDto.Message = "Vracanje svih zasticenih zona";

            List<ZasticenaZonaEntity> zasticeneZone = zasticenaZonaRepository.GetZasticeneZone();
            if (zasticeneZone == null || zasticeneZone.Count == 0)
            {
                logDto.Level = "Warn";
                loggerService.CreateLog(logDto);
                return NoContent();
            }
            logDto.Level = "Info";
            loggerService.CreateLog(logDto);
            return Ok(mapper.Map<List<ZasticenaZonaDto>>(zasticeneZone));
        }

       
        [HttpGet("{zasticenaZonaID}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ZasticenaZonaDto> GetZasticenaZona(Guid zasticenaZonaID)
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
            logDto.Message = "Vracanje zasticene zone po ID-ju";

            ZasticenaZonaEntity zasticenaZona = zasticenaZonaRepository.GetZasticenaZonaById(zasticenaZonaID);
            if (zasticenaZona == null)
            {
                logDto.Level = "Warn";
                loggerService.CreateLog(logDto);
                return NotFound();
            }
            logDto.Level = "Info";
            loggerService.CreateLog(logDto);
            return Ok(mapper.Map<ZasticenaZonaDto>(zasticenaZona));
        }

       
        [HttpPost]
        [HttpHead]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZasticenaZonaDto> CreateZasticenaZona([FromBody] ZasticenaZonaCreateDto zasticenaZona)
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
            logDto.Message = "Dodavanje nove zasticene zone";

            try
            {
                ZasticenaZonaEntity zaz = mapper.Map<ZasticenaZonaEntity>(zasticenaZona);
                ZasticenaZonaEntity z = zasticenaZonaRepository.CreateZasticenaZona(zaz);
                zasticenaZonaRepository.SaveChanges();
                string location = linkGenerator.GetPathByAction("GetZasticenaZona", "ZasticenaZona", new { zasticenaZonaID = z.ZasticenaZonaID });
                logDto.Level = "Info";
                loggerService.CreateLog(logDto);
                return Created(location, mapper.Map<ZasticenaZonaDto>(z));
            }
            catch
            {
                logDto.Level = "Error";
                loggerService.CreateLog(logDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        
        [HttpDelete("{zasticenaZonaID}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteZasticenaZona(Guid zasticenaZonaID)
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
            logDto.Message = "Brisanje zasticene zone";
            try
            {
                ZasticenaZonaEntity zasticenaZona = zasticenaZonaRepository.GetZasticenaZonaById(zasticenaZonaID);
                if (zasticenaZona == null)
                {
                    logDto.Level = "Warn";
                    loggerService.CreateLog(logDto);
                    return NotFound();
                }
                zasticenaZonaRepository.DeleteZasticenaZona(zasticenaZonaID);
                zasticenaZonaRepository.SaveChanges();
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
        public ActionResult<ZasticenaZonaDto> UpdateZasticenaZona(ZasticenaZonaUpdateDto zasticenaZona)
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
            logDto.Message = "Modifikovanje zasticene zone";

            try
            {
                var oldZasticenaZona = zasticenaZonaRepository.GetZasticenaZonaById(zasticenaZona.ZasticenaZonaID);
                if (oldZasticenaZona == null)
                {
                    logDto.Level = "Warn";
                    loggerService.CreateLog(logDto);
                    return NotFound();
                }
                ZasticenaZonaEntity zasticenaZonaEntity = mapper.Map<ZasticenaZonaEntity>(zasticenaZona);

                mapper.Map(zasticenaZonaEntity, oldZasticenaZona);

                zasticenaZonaRepository.SaveChanges();
                logDto.Level = "Info";
                loggerService.CreateLog(logDto);
                return Ok(mapper.Map<ZasticenaZonaDto>(zasticenaZonaEntity));
            }
            catch (Exception)
            {
                logDto.Level = "Error";
                loggerService.CreateLog(logDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

       
        [HttpOptions]
        public IActionResult GetZasticenaZonaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            logDto.HttpMethod = "OPTIONS";
            logDto.Message = "Opcije za rad sa zasticenim zonama";
            logDto.Level = "Info";
            loggerService.CreateLog(logDto);
            return Ok();
        }
    }
}
