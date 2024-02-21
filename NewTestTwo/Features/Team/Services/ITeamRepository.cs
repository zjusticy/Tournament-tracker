using NewTestTwo.Features.Team.Models;

namespace NewTestTwo.Features.Team.Services
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamModel>> GetTeamsAsync(int tournamentId);

        Task<TeamModel?> GetSingleTeamAsync(int tournamentId, int teamId);

        Task<bool> TeamExistsAsync(int teamId);

        void AddTeam(int tournamentId, TeamModel team);

        void UpdateTeam(TeamModel team);

        void DeleteTeam(TeamModel team);
    }
}
