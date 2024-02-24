using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TournamentTracker.Features.Tournament.Models;
using TournamentTracker.Features.Tournament.Models.Dtos;
using TournamentTracker.Features.Tournament.Services;

namespace TournamentTracker.Features.Tournament.Controllers
{
    [Route("api/tournaments")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;
        private readonly ITournamentLogic _tournamentLogic;

        public TournamentController(IMapper mapper, ITournamentRepository tournamentRepository, ITournamentLogic tournamentLogic)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
            _tournamentLogic = tournamentLogic;
        }


        [HttpGet(Name = nameof(GetTournaments))]
        public async Task<ActionResult<IEnumerable<TournamentDTO>>> GetTournaments()
        {
            var tournaments = await _tournamentRepository.GetTournamentsAsync();
            var tournamentsDto = _mapper.Map<IEnumerable<TournamentDTO>>(tournaments);

            return Ok(tournamentsDto);
        }


        [HttpGet("{tournamentId}", Name = nameof(GetTournament))]
        public async Task<ActionResult<TournamentModel>> GetTournament(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetSingleTournamentAsync(tournamentId);

            if (tournament == null)
            {
                return NotFound();
            }

            var tournamentDetailDTO = _mapper.Map<TournamentDetailDTO>(tournament);

            return Ok(tournamentDetailDTO);
        }


        [HttpPost(Name = nameof(CreateTournament))]
        public async Task<ActionResult<TournamentModel>> CreateTournament(TournamentAddDTO tournamentDTO)
        {
            var tournament = _mapper.Map<TournamentModel>(tournamentDTO);
            await _tournamentRepository.AddTournament(tournament);

            var tournamentDTOForReturn = _mapper.Map<TournamentDTO>(tournament);

            return CreatedAtAction(nameof(GetTournament), new { tournamentId = tournamentDTOForReturn.Id }, tournamentDTOForReturn);
        }

        [HttpPatch("{tournamentId}")]
        public async Task<IActionResult> PartiallyUpdateTournament(int tournamentId, JsonPatchDocument<TournamentUpdateDTO> tournamentPatchDoc)
        {
            var tournament = await _tournamentRepository.GetSingleTournamentAsync(tournamentId);

            if (tournament == null)
            {
                return NotFound();
            }

            var tournamentDtoToPatch = _mapper.Map<TournamentUpdateDTO>(tournament);

            tournamentPatchDoc.ApplyTo(tournamentDtoToPatch);

            if (tournamentDtoToPatch.KickedOff == true && tournament.KickedOff == false)
            {
                var teams = tournament.EnteredTeams.ToList();

                await _tournamentLogic.AddRounds(teams, tournament);

                /*  foreach (var matchup in matchups)
                  {
                      _tournamentRepository.AddMatchup(tournamentId, matchup);
                  }

                  tournament.KickedOff = true;

                  _tournamentRepository.UpdateTournament(tournament);

                  await _unitOfWork.SaveAsync();*/

                return NoContent();
            }

            _mapper.Map(tournamentDtoToPatch, tournament);

            await _tournamentRepository.UpdateTournament(tournament);

            return NoContent();
        }


        [HttpPut("{tournamentId}")]
        public async Task<ActionResult<TournamentModel>> UpdateTournament(int tournamentId, TournamentUpdateDTO tournamentDTO)
        {
            var tournament = await _tournamentRepository.GetSingleTournamentAsync(tournamentId);

            if (tournament == null)
            {
                var tournamentToAdd = _mapper.Map<TournamentModel>(tournamentDTO);
                tournamentToAdd.Id = tournamentId;
                await _tournamentRepository.AddTournament(tournamentToAdd);

                var tournamentDTOForReturn = _mapper.Map<TournamentDTO>(tournamentToAdd);

                return CreatedAtRoute(nameof(GetTournament), new
                {
                    tournamentId = tournamentDTOForReturn.Id
                }, tournamentDTOForReturn);
            }

            _mapper.Map(tournamentDTO, tournament);

            await _tournamentRepository.UpdateTournament(tournament);

            return NoContent();
        }


        [HttpDelete("{tournamentId}")]
        public async Task<IActionResult> DeleteTournament(int tournamentId)
        {

            var tournament = await _tournamentRepository.GetSingleTournamentAsync(tournamentId);

            if (tournament == null)
            {
                return NotFound();
            }

            await _tournamentRepository.DeleteTournament(tournament);

            return NoContent();
        }
    }
}
