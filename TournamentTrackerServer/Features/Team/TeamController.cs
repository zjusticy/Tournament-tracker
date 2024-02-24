using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentTracker.Features.Team.Models;
using TournamentTracker.Features.Team.Services;
using TournamentTracker.Features.Tournament.Services;

namespace TournamentTracker.Features.Team
{
    [Route("api/{tournamentId}/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public TeamController(IMapper mapper, ITeamRepository teamRepository, ITournamentRepository tournamentRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
            _tournamentRepository = tournamentRepository ?? throw new ArgumentNullException(nameof(tournamentRepository));
        }


        [HttpGet(Name = nameof(GetTeamsOfTournament))]
        public async Task<ActionResult<IEnumerable<TeamModel>>> GetTeamsOfTournament(int tournamentId)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }

            var teams = await _teamRepository.GetTeamsAsync(tournamentId);

            var teamsDTO = _mapper.Map<IEnumerable<TeamDTO>>(teams);

            return Ok(teamsDTO);
        }


        [HttpGet("{teamId}", Name = nameof(GetTeam))]
        public async Task<ActionResult<TeamModel>> GetTeam(int tournamentId, int teamId)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }
            var team = await _teamRepository.GetSingleTeamAsync(tournamentId, teamId);

            if (team == null)
            {
                return NotFound();
            }

            var teamDetailDTO = _mapper.Map<TeamDetailDTO>(team);

            return Ok(teamDetailDTO);
        }


        [HttpPost(Name = nameof(CreateTeamForTournament))]
        public async Task<ActionResult<TeamModel>> CreateTeamForTournament(int tournamentId, TeamAddDTO teamDTO)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }
            var team = _mapper.Map<TeamModel>(teamDTO);
            await _teamRepository.AddTeam(tournamentId, team);

            var teamDTOForReturn = _mapper.Map<TeamDTO>(team);

            return CreatedAtAction(nameof(GetTeam), new { tournamentId, teamId = teamDTOForReturn.Id }, teamDTOForReturn);
        }


        [HttpPut("{teamId}")]
        public async Task<ActionResult<TeamModel>> UpdateTeamOfTournament(int tournamentId, int teamId, TeamUpdateDTO teamDTO)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }

            var team = await _teamRepository.GetSingleTeamAsync(tournamentId, teamId);

            if (team == null)
            {
                var teamToAdd = _mapper.Map<TeamModel>(teamDTO);
                teamToAdd.Id = teamId;
                await _teamRepository.AddTeam(tournamentId, teamToAdd);

                var teamDTOForReturn = _mapper.Map<TeamDTO>(teamToAdd);

                return CreatedAtRoute(nameof(GetTeam), new
                {
                    teamId,
                    personId = teamDTOForReturn.Id
                }, teamDTOForReturn);
            }

            _mapper.Map(teamDTO, team);

            await _teamRepository.UpdateTeam(team);

            return NoContent();
        }


        [HttpDelete("{teamId}")]
        public async Task<IActionResult> DeleteTeam(int tournamentId, int teamId)
        {
            if (!await _tournamentRepository.TournamentExistsAsync(tournamentId))
            {
                return NotFound();
            }

            var team = await _teamRepository.GetSingleTeamAsync(tournamentId, teamId);

            if (team == null)
            {
                return NotFound();
            }

            await _teamRepository.DeleteTeam(team);

            return NoContent();
        }
    }
}
