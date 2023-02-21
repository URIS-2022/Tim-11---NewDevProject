using System;    
using AutoMapper;
using UplataService.DtoModels;
using UplataService.Entities.cs;
using UplataService.Repositories;
using UplataService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace UplataService.Controllers
{
	[ApiController]
	[Route("api/banke")]
	[Produces("application/json", "application/xml")]
	public class BankaController : ControllerBase
    {
		private readonly IBankaRepository bankaRepository;
		private readonly IMapper mapper;

		public BankaController(IBankaRepository bankaRepository, IMapper mapper)
		{
			this.mapper = mapper;
			this.bankaRepository = bankaRepository;
		}

		[HttpGet]
		[HttpHead]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<BankaDto>> getAllBanke()
		{
			List<Banka> banke = bankaRepository.getAllBanke();

			if(banke == null || banke.Count == 0)
			{
				return NoContent();
			}

			return Ok(mapper.Map<List<BankaDto>>(banke));
		}

		[HttpGet("{bankaId}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<BankaDto> getBankaById (Guid bankaId)
		{
			Banka bk = bankaRepository.getBankaById(bankaId);
			if(bk == null)
			{
				return NotFound();
			}

			return Ok(mapper.Map<BankaDto>(bk));
		}

		[HttpDelete("{bankaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteBanka (Guid bankaId)
		{
			try
			{
                Banka bk = bankaRepository.getBankaById(bankaId);
                if (bk == null)
                {
                    return NotFound();
                }

                bankaRepository.deleteBanka(bankaId);
                bankaRepository.SaveChanges();
                return NoContent();

            }catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
			}
			
		}

		[HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
		[Produces("application/json")]
        public ActionResult<BankaDto> postBanka([FromBody] BankaDto uplata)
		{
			try
			{
				Banka bnk = mapper.Map<Banka>(uplata);
                Banka banka = bankaRepository.postBanka(bnk);
				bankaRepository.SaveChanges();
				return Created("uri",mapper.Map<BankaDto>(bnk));

            }catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
			}
			

		}

		[HttpPut]
		[Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult putBanka(BankaUpdateDto uplata)
		{
			try
			{
				Banka banka = mapper.Map<Banka>(uplata);
				Banka bk = bankaRepository.getBankaById(banka.bankaId);

				if (bk == null)
				{
					return NotFound();
				}

				Banka bank = mapper.Map<Banka>(banka);
				mapper.Map(bank, bk);
				bankaRepository.SaveChanges();
				return Ok(mapper.Map<BankaDto>(bk));

			}catch(Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Put error");
			}
		}
	}
}

