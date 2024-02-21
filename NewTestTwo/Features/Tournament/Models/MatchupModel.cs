using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewTestTwo.Features.Team.Models;

namespace NewTestTwo.Features.Tournament.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// The unique identifier for the match
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The ID from the database that will be used to idnetify the winner
        /// </summary>
        [ForeignKey(nameof(Winner))]
        public int? WinnerId { get; set; }

        /// <summary>
        /// The winner team of the match
        /// </summary>
        public TeamModel? Winner { get; set; }

        /// <summary>
        /// Which round this match is part of
        /// </summary>
        public int MatchupRound { get; set; }

        /// <summary>
        /// The unique identifier for the Tournament
        /// </summary>
        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }

        /// <summary>
        /// The Tournament this matchup belongs
        /// </summary>
        public TournamentModel Tournament { get; set; } = null!;

        /// <summary>
        /// The set of teams that were involved in this match
        /// </summary>
        public ICollection<MatchupEntryModel> Entries { get; } = new List<MatchupEntryModel>();

        /// <summary>
        /// The matchup entry followed this matchup
        /// </summary>
        public MatchupEntryModel? ChildEntry { get; }
    }
}
