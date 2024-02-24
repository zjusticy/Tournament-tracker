using TournamentTracker.Features.Team.Models;
using TournamentTracker.Features.Tournament.Models;

namespace TournamentTracker.Features.Tournament.Services
{
    public interface ITournamentLogic
    {
        Task AddRounds(ICollection<TeamModel> enteredTeams, TournamentModel tournament);
    }
}