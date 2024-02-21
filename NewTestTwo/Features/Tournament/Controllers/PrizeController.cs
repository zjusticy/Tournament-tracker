using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewTestTwo.Features.Tournament.Models;
using NewTestTwo.Features.Tournament.Models.Dtos;
using NewTestTwo.Features.Tournament.Services;

namespace NewTestTwo.Features.Tournament.Controllers
{
    [Route("api/{tournamentId}/prizes")]
    [ApiController]
    public class PrizeController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public PrizeController(IMapper mapper, ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }


        [HttpGet(Name = nameof(GetPrizesOfTournament))]
        public async Task<ActionResult<IEnumerable<PrizeDTO>>> GetPrizesOfTournament(int tournamentId)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }

            var prizes = await _tournamentRepository.GetPrizesAsync(tournamentId);

            var prizesDTO = _mapper.Map<IEnumerable<PrizeDTO>>(prizes);

            return Ok(prizesDTO);
        }


        [HttpGet("{prizeId}", Name = nameof(GetPrize))]
        public async Task<ActionResult<PrizeDTO>> GetPrize(int tournamentId, int prizeId)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }
            var prize = await _tournamentRepository.GetSinglePrizeAsync(tournamentId, prizeId);

            if (prize == null)
            {
                return NotFound();
            }

            var prizeDTO = _mapper.Map<PrizeDTO>(prize);

            return Ok(prizeDTO);
        }


        [HttpPost(Name = nameof(CreatePrizeForTournament))]
        public async Task<ActionResult<PrizeDTO>> CreatePrizeForTournament(int tournamentId, PrizeAddDTO prizeDTO)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }

            var prize = _mapper.Map<PrizeModel>(prizeDTO);
            _tournamentRepository.AddPrize(tournamentId, prize);
            await _tournamentRepository.SaveAsync();

            var prizeDTOForReturn = _mapper.Map<PrizeDTO>(prize);

            return CreatedAtAction(nameof(GetPrize), new { tournamentId, prizeId = prizeDTOForReturn.Id }, prizeDTOForReturn);
        }


        [HttpPut("{prizeId}")]
        public async Task<ActionResult<PrizeDTO>> UpdatePrizeOfTournament(int tounamentId, int prizeId, PrizeUpdateDTO prizeDTO)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tounamentId))
            {
                return NotFound();
            }

            var prize = await _tournamentRepository.GetSinglePrizeAsync(tounamentId, prizeId);

            if (prize == null)
            {
                var prizeToAdd = _mapper.Map<PrizeModel>(prizeDTO);
                prizeToAdd.Id = prizeId;
                _tournamentRepository.AddPrize(tounamentId, prizeToAdd);

                await _tournamentRepository.SaveAsync();

                var prizeDTOForReturn = _mapper.Map<PrizeDTO>(prizeToAdd);

                return CreatedAtRoute(nameof(GetPrize), new
                {
                    tounamentId,
                    prizeId = prizeDTOForReturn.Id
                }, prizeDTOForReturn);
            }

            _mapper.Map(prizeDTO, prize);

            _tournamentRepository.UpdatePrize(prize);

            await _tournamentRepository.SaveAsync();

            return NoContent();
        }


        [HttpDelete("{prizeId}")]
        public async Task<IActionResult> DeletePrize(int tournamentId, int prizeId)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }

            var prize = await _tournamentRepository.GetSinglePrizeAsync(tournamentId, prizeId);

            if (prize == null)
            {
                return NotFound();
            }

            _tournamentRepository.DeletePrize(prize);

            await _tournamentRepository.SaveAsync();

            return NoContent();
        }
    }
}
