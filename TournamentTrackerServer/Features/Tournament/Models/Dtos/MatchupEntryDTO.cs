using TournamentTracker.Features.Team.Models;

namespace TournamentTracker.Features.Tournament.Models.Dtos
{
    public class MatchupEntryDTO
    {
        /// <summary>
        /// The unique identifier for the matchup entry
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents one team in the matchup
        /// </summary>
        public TeamDTO TeamCompeting { get; set; } = null!;

        /// <summary>
        /// Represents the score of this team
        /// </summary>
        public double Score { get; set; }
    }
}
