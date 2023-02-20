using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dokument.Entities;
using Dokument.Repositories;
using Dokument.DtoModels;
using Dokument.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dokument.Controllers
{

    [ApiController]
    [Route("api/korisnici")]
    [Produces("application/json", "application/xml")]
    public class KorisnikController : ControllerBase
    {
        private readonly IDokument dokumentrep;
        private readonly IMapper mapper;
        public KorisnikController(IDokument dokumentrep, IMapper mapper)
        {
            this.dokumentrep = dokumentrep;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<DokumentDto>> getDokument()
        {
            List<Entities.Dokument> dokumenti = dokumentrep.getDokument();

            if (dokumenti == null || dokumenti.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<DokumentDto>>(dokumenti));
        }

        [HttpGet("{dokumentId}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<DokumentDto> getDokumentByID(Guid dokumentId)
        {
            Entities.Dokument d = dokumentrep.getDokumentByID(dokumentId);
            if (d == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DokumentDto>(d));
        }

        [HttpDelete("{dokumentId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteDokument(Guid dokumentId)
        {
            try
            {
                Entities.Dokument d = dokumentrep.getDokumentByID(dokumentId);
                if (d == null)
                {
                    return NotFound();
                }

                dokumentrep.deleteDokument(dokumentId);
                dokumentrep.saveChanges();
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }

        }
        /*
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json")]
        public ActionResult<DokumentDto> postDokument([FromBody] DokumentCreation dokument)
        {
            try
            {
                Entities.Dokument d = mapper.Map<Entities.Dokument>(dokument);
                Dokument dok = dokumentrep.postDokument(d);
                dokumentrep.saveChanges();
                return Created("uri", mapper.Map<DokumentDto>(do));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }


        }
        */
        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult putKorisnik(DokumentUpdateDto dokument)
        {
            try
            {
                Entities.Dokument Dokument = mapper.Map<Entities.Dokument>(dokument);
                Entities.Dokument d = dokumentrep.getDokumentByID(Dokument.DokumentId);

                if (d == null)
                {
                    return NotFound();
                }


                DokumentDto dokDto = mapper.Map<DokumentDto>(dokument);
                mapper.Map(dokDto, d);
                return Ok(mapper.Map<DokumentDto>(d));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Put error");
            }
        }
    }
}




