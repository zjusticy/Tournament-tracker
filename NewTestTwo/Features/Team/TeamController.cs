﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewTestTwo.Features.Team.Models;
using NewTestTwo.Features.Team.Services;
using NewTestTwo.Features.Tournament.Services;
using NewTestTwo.Infrastructure.Repositories;

namespace NewTestTwo.Features.Team
{
    [Route("api/{tournamentId}/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamController(IMapper mapper, ITeamRepository teamRepository, ITournamentRepository tournamentRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
            _tournamentRepository = tournamentRepository ?? throw new ArgumentNullException(nameof(tournamentRepository));
            _unitOfWork = unitOfWork;
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
            _teamRepository.AddTeam(tournamentId, team);
            await _unitOfWork.SaveAsync();

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
                _teamRepository.AddTeam(tournamentId, teamToAdd);

                await _unitOfWork.SaveAsync();

                var teamDTOForReturn = _mapper.Map<TeamDTO>(teamToAdd);

                return CreatedAtRoute(nameof(GetTeam), new
                {
                    teamId,
                    personId = teamDTOForReturn.Id
                }, teamDTOForReturn);
            }

            _mapper.Map(teamDTO, team);

            _teamRepository.UpdateTeam(team);

            await _unitOfWork.SaveAsync();

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

            _teamRepository.DeleteTeam(team);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
