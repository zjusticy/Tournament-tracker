using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TournamentTracker.Features.Team.Models;

namespace TournamentTracker.Features.Tournament.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// The unique identifier for the matchup entry
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier for the team
        /// </summary>
        [ForeignKey(nameof(TeamCompeting))]
        public int? TeamId { get; set; }

        /// <summary>
        /// Represents one team in the matchup
        /// </summary>
        public TeamModel? TeamCompeting { get; set; }

        /// <summary>
        /// Represents the score of this team
        /// </summary>
        public double? Score { get; set; }

        /// <summary>
        /// The unique identifierr for the matchup this entry belongs
        /// </summary>
        public int MatchupId { get; set; }

        /// <summary>
        /// Represents the matchup that this entry belongs
        /// </summary>
        public MatchupModel Matchup { get; set; } = null!;

        /// <summary>
        /// The unique identifierr for the matchup this entry belongs
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Represents the matchup that this entry belongs
        /// </summary>
        public MatchupModel? ParentMatchup { get; set; }
    }
}
