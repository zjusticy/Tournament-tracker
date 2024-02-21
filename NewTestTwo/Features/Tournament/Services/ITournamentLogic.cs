using NewTestTwo.Features.Team.Models;
using NewTestTwo.Features.Tournament.Models;

namespace NewTestTwo.Features.Tournament.Services
{
    public interface ITournamentLogic
    {
        List<MatchupModel> CreateRounds(ICollection<TeamModel> enteredTeams);
    }
}