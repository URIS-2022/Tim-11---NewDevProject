using System;
using AutoMapper;
using UplataService.DtoModels;
using UplataService.Entities.cs;
using UplataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UplataService.Controllers
{
	[ApiController]
    [Route("api/uplate")]
    [Produces("application/json", "application/xml")]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository uplataRepository;
        private readonly IMapper mapper;
        public UplataController(IUplataRepository uplataRepository, IMapper mapper)
		{
            this.uplataRepository = uplataRepository;
            this.mapper = mapper;
		}

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<UplataDto>> getAllUplate()
        {
            List<Uplata> uplate = uplataRepository.getAllUplate();

            if (uplate == null || uplate.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<UplataDto>>(uplate));
        }

        [HttpGet("{uplataId}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UplataDto> getUplataById(Guid uplataId)
        {
            Uplata u = uplataRepository.getUplataById(uplataId);
            if (u == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UplataDto>(u));
        }

        [HttpDelete("{uplataId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteUplata(Guid uplataId)
        {
            try
            {
                Uplata u = uplataRepository.getUplataById(uplataId);
                if (u == null)
                {
                    return NotFound();
                }

                uplataRepository.deleteUplata(uplataId);
                uplataRepository.SaveChanges();
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces("application/json")]
        public ActionResult<UplataDto> postUplata([FromBody] UplataCreateDto uplata)
        {
            try
            {
                Uplata U = mapper.Map<Uplata>(uplata);
                Uplata upl = uplataRepository.postUplata(U);
                uplataRepository.SaveChanges();
                return Created("uri", mapper.Map<UplataDto>(upl));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }


        }

        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult putUplata(UplataUpdateDto uplata)
        {
            try
            {
                Uplata Uplata = mapper.Map<Uplata>(uplata);
                Uplata u = uplataRepository.getUplataById(Uplata.uplataId);

                if (u == null)
                {
                    return NotFound();
                }


                UplataDto uplataDto = mapper.Map<UplataDto>(uplata);
                mapper.Map(uplataDto, u);
                return Ok(mapper.Map<UplataDto>(u));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Put error");
            }
        }
    }
}

