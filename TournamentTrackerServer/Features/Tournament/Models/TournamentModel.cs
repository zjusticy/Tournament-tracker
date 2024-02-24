using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TournamentTracker.Features.Team.Models;

namespace TournamentTracker.Features.Tournament.Models
{
    /// <summary>
    /// Pepresents one tournament, with all fo the rounds, matchups, prizes and outcomes
    /// </summary>
    public class TournamentModel
    {
        /// <summary>
        /// The unique identifier for the tournament
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name given to this tournament
        /// </summary>
        [MaxLength(60)]
        [MinLength(3)]
        public string TournamentName { get; set; } = string.Empty;

        /// <summary>
        /// The amount of mouney each team needs to put up to enter
        /// </summary>
        [Precision(14, 2)]
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Whether this tournament kick off
        /// </summary>
        public bool KickedOff { get; set; } = false;

        /// <summary>
        /// The set of teams that have been entered
        /// </summary>
        public ICollection<TeamModel> EnteredTeams { get; } = new List<TeamModel>();

        /// <summary>
        /// The list of prizes for the various places
        /// </summary>
        public ICollection<PrizeModel> Prizes { get; } = new List<PrizeModel>();

        /// <summary>
        /// The matchups per round
        /// </summary>
        public ICollection<MatchupModel> TournamentMatchups { get; } = new List<MatchupModel>();

    }
}
