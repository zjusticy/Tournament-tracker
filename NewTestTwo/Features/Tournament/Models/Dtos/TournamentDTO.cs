using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NewTestTwo.Features.Tournament.Models.Dtos
{
    /// <summary>
    /// Pepresents one tournament, with all fo the rounds, matchups, prizes and outcomes
    /// </summary>
    public class TournamentDTO
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
        /// Whether this tournament kick off
        /// </summary>
        public bool KickedOff { get; set; }
    }
}
