using TournamentTracker.Features.Team.Models;

namespace TournamentTracker.Features.Team.Services
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamModel>> GetTeamsAsync(int tournamentId);

        Task<TeamModel?> GetSingleTeamAsync(int tournamentId, int teamId);

        Task<bool> TeamExistsAsync(int teamId);

        Task AddTeam(int tournamentId, TeamModel team);

        Task UpdateTeam(TeamModel team);

        Task DeleteTeam(TeamModel team);
    }
}
