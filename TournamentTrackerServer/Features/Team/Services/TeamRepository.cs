using Microsoft.EntityFrameworkCore;
using TournamentTracker.DbContexts;
using TournamentTracker.Features.Team.Models;

namespace TournamentTracker.Features.Team.Services
{
    public class TeamRepository : ITeamRepository
    {

        private readonly TournamentTrackerContext _context;

        public TeamRepository(TournamentTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamModel>> GetTeamsAsync(int tournamentId)
        {
            var teams = _context.Teams.Where(x => x.TournamentId == tournamentId);
            return await teams.ToListAsync();
        }

        public async Task<TeamModel?> GetSingleTeamAsync(int tournamentId, int teamId)
        {
            return await _context.Teams.Where(x => x.Id == teamId && x.TournamentId == tournamentId).Include(t => t.TeamMembers).FirstOrDefaultAsync();
        }


        public async Task AddTeam(int tournamentId, TeamModel team)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            team.TournamentId = tournamentId;

            _context.Teams.Add(team);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeam(TeamModel team)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeam(TeamModel team)
        {
            _context.Teams.Remove(team);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> TeamExistsAsync(int teamId)
        {
            return await _context.Teams.AnyAsync(x => x.Id == teamId);
        }
    }
}
