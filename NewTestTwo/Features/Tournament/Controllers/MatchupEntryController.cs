using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewTestTwo.Features.Tournament.Models;
using NewTestTwo.Features.Tournament.Models.Dtos;
using NewTestTwo.Features.Tournament.Services;

namespace NewTestTwo.Features.Tournament.Controllers
{
    [Route("api/{matchupId}/matchupentries")]
    [ApiController]
    public class MatchupEntryController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public MatchupEntryController(IMapper mapper, ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }


        [HttpGet(Name = nameof(GetMatchupEntriesOfMatchup))]
        public async Task<ActionResult<IEnumerable<MatchupDTO>>> GetMatchupEntriesOfMatchup(int matchupId)
        {
            if (!await _tournamentRepository.MatchupExistsAsync(matchupId))
            {
                return NotFound();
            }

            var matchupEntris = await _tournamentRepository.GetMatchupEntriesAsync(matchupId);

            var matchupEntrisDTO = _mapper.Map<IEnumerable<MatchupEntryDTO>>(matchupEntris);

            return Ok(matchupEntrisDTO);
        }


        [HttpGet("{matchupEntryId}", Name = nameof(GetMatchupEntry))]
        public async Task<ActionResult<MatchupDTO>> GetMatchupEntry(int matchupId, int matchupEntryId)
        {
            if (!await _tournamentRepository.MatchupExistsAsync(matchupId))
            {
                return NotFound();
            }
            var matchupEntry = await _tournamentRepository.GetSingleMatchupEntryAsync(matchupId, matchupEntryId);

            if (matchupEntry == null)
            {
                return NotFound();
            }

            var matchupEntryDTO = _mapper.Map<MatchupEntryDTO>(matchupEntry);

            return Ok(matchupEntryDTO);
        }


        /*        [HttpPost(Name = nameof(CreateMatchupEntryForMatchup))]
                public async Task<ActionResult<MatchupDTO>> CreateMatchupEntryForMatchup(int matchupId, MatchupEntryAddDTO matchupEntryDTO)
                {
                    if (!await _tournamentRepository.MatchupExistsAsync(matchupId))
                    {
                        return NotFound();
                    }

                    var matchupEntry = _mapper.Map<MatchupEntryModel>(matchupEntryDTO);
                    _tournamentRepository.AddMatchupEntryForMatchup(matchupId, matchupEntry);
                    await _tournamentRepository.SaveAsync();

                    var matchupEntryDTOForReturn = _mapper.Map<MatchupEntryDTO>(matchupEntry);

                    return CreatedAtAction(nameof(GetMatchupEntry), new { matchupId, matchupEntryId = matchupEntryDTOForReturn.Id }, matchupEntryDTOForReturn);
                }*/


        [HttpPut("{matchupEntryId}")]
        public async Task<ActionResult<PrizeDTO>> UpdateMatchupEntryForMatchup(int matchupId, int matchupEntryId, MatchupEntryUpdateDTO matchupEntryDTO)
        {
            if (!await _tournamentRepository.MatchupExistsAsync(matchupId))
            {
                return NotFound();
            }

            var matchupEntry = await _tournamentRepository.GetSingleMatchupEntryAsync(matchupId, matchupEntryId);

            if (matchupEntry == null)
            {
                var matchupEntryToAdd = _mapper.Map<MatchupEntryModel>(matchupEntryDTO);
                matchupEntryToAdd.Id = matchupEntryId;
                _tournamentRepository.AddMatchupEntryForMatchup(matchupId, matchupEntryToAdd);

                await _tournamentRepository.SaveAsync();

                var matchupEntryDTOForReturn = _mapper.Map<MatchupEntryDTO>(matchupEntryToAdd);

                return CreatedAtRoute(nameof(GetMatchupEntry), new
                {
                    matchupId,
                    matchupEntryId = matchupEntryDTOForReturn.Id
                }, matchupEntryDTOForReturn);
            }

            _mapper.Map(matchupEntryDTO, matchupEntry);

            _tournamentRepository.UpdateMatchupEntry(matchupEntry);

            await _tournamentRepository.SaveAsync();

            return NoContent();
        }


        [HttpDelete("{matchupEntryId}")]
        public async Task<IActionResult> DeleteMatchupEntry(int matchupId, int matchupEntryId)
        {
            if (!await _tournamentRepository.MatchupExistsAsync(matchupId))
            {
                return NotFound();
            }

            var matchupEntry = await _tournamentRepository.GetSingleMatchupEntryAsync(matchupId, matchupEntryId);

            if (matchupEntry == null)
            {
                return NotFound();
            }

            _tournamentRepository.DeleteMatchupEntry(matchupEntry);

            await _tournamentRepository.SaveAsync();

            return NoContent();
        }
    }
}
