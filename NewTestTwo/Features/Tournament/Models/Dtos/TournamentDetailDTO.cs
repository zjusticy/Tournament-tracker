using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NewTestTwo.Features.Team.Models;

namespace NewTestTwo.Features.Tournament.Models.Dtos
{
    /// <summary>
    /// Pepresents one tournament, with all fo the rounds, matchups, prizes and outcomes
    /// </summary>
    public class TournamentDetailDTO
    {
        /// <summary>
        /// The unique identifier for the tournament
        public int Id { get; set; }


        /// <summary>
        /// The name given to this tournament
        /// </summary>
        [MaxLength(100)]
        public string TournamentName { get; set; } = string.Empty;

        /// <summary>
        /// The amount of mouney each team needs to put up to enter
        /// </summary>
        [Precision(18, 2)]
        public decimal EntryFee { get; set; }

        /// <summary>
        /// The list of prizes for the various places
        /// </summary>
        public ICollection<PrizeDTO> Prizes { get; } = new List<PrizeDTO>();

        /// <summary>
        /// The set of teams that have been entered
        /// </summary>
        public ICollection<TeamDTO> EnteredTeams { get; } = new List<TeamDTO>();


        /// <summary>
        /// Whether this tournament kick off
        /// </summary>
        public bool KickedOff { get; set; }
    }
}
