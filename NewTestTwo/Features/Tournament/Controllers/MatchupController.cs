using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewTestTwo.Features.Tournament.Models;
using NewTestTwo.Features.Tournament.Models.Dtos;
using NewTestTwo.Features.Tournament.Services;

namespace NewTestTwo.Features.Tournament.Controllers
{
    [Route("api/{tournamentId}/matchups")]
    [ApiController]
    public class MatchupController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public MatchupController(IMapper mapper, ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }


        [HttpGet(Name = nameof(GetMatchupsOfTournament))]
        public async Task<ActionResult<IEnumerable<MatchupDTO>>> GetMatchupsOfTournament(int tournamentId)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }

            var matchups = await _tournamentRepository.GetMatchupsAsync(tournamentId);

            var matchupsDTO = _mapper.Map<IEnumerable<MatchupDTO>>(matchups);

            return Ok(matchupsDTO);
        }


        [HttpGet("{matchupId}", Name = nameof(GetMatchup))]
        public async Task<ActionResult<MatchupDetailDTO>> GetMatchup(int tournamentId, int matchupId)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }
            var matchup = await _tournamentRepository.GetSingleMatchupAsync(tournamentId, matchupId);

            if (matchup == null)
            {
                return NotFound();
            }

            var matchupDTO = _mapper.Map<MatchupDetailDTO>(matchup);

            return Ok(matchupDTO);
        }


        /*        [HttpPost(Name = nameof(CreateMatchupForTournament))]
                public async Task<ActionResult<MatchupDTO>> CreateMatchupForTournament(int tournamentId, PrizeAddOrUpdateDTO matchupDTO)
                {
                    if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
                    {
                        return NotFound();
                    }

                    var matchup = _mapper.Map<MatchupModel>(matchupDTO);
                    _tournamentRepository.AddMatchup(tournamentId, matchup);
                    await _tournamentRepository.SaveAsync();

                    var matchupDTOForReturn = _mapper.Map<MatchupDTO>(matchup);

                    return CreatedAtAction(nameof(GetMatchup), new { tournamentId, prizeId = matchupDTOForReturn.Id }, matchupDTOForReturn);
                }*/


        [HttpPut("{matchupId}")]
        public async Task<ActionResult<PrizeDTO>> UpdatePrizeOfTournament(int tounamentId, int matchupId, PrizeAddOrUpdateDTO matchupDTO)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tounamentId))
            {
                return NotFound();
            }

            var matchup = await _tournamentRepository.GetSingleMatchupAsync(tounamentId, matchupId);

            if (matchup == null)
            {
                var matchupToAdd = _mapper.Map<MatchupModel>(matchupDTO);
                matchupToAdd.Id = matchupId;
                _tournamentRepository.AddMatchup(tounamentId, matchupToAdd);

                await _tournamentRepository.SaveAsync();

                var matchupDTOForReturn = _mapper.Map<MatchupDTO>(matchupToAdd);

                return CreatedAtRoute(nameof(GetMatchup), new
                {
                    tounamentId,
                    matchupId = matchupDTOForReturn.Id
                }, matchupDTOForReturn);
            }

            _mapper.Map(matchupDTO, matchup);

            _tournamentRepository.UpdateMatchup(matchup);

            await _tournamentRepository.SaveAsync();

            return NoContent();
        }


        [HttpDelete("{matchupId}")]
        public async Task<IActionResult> DeleteMatchupModel(int tournamentId, int matchupId)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }

            var matchup = await _tournamentRepository.GetSingleMatchupAsync(tournamentId, matchupId);

            if (matchup == null)
            {
                return NotFound();
            }

            _tournamentRepository.DeleteMatchup(matchup);

            await _tournamentRepository.SaveAsync();

            return NoContent();
        }
    }
}
