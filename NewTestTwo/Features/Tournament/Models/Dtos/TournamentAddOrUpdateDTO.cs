using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NewTestTwo.Features.Tournament.Models.Dtos
{
    /// <summary>
    /// Pepresents one tournament, with all fo the rounds, matchups, prizes and outcomes
    /// </summary>
    public class TournamentAddOrUpdateDTO
    {
        /// <summary>
        /// The name given to this tournament
        /// </summary>
        [DisplayName("Tournament Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "The length of the {0} must be between {2} and {1}")]
        public string TournamentName { get; set; } = string.Empty;

        /// <summary>
        /// The amount of mouney each team needs to put up to enter
        /// </summary>
        [DisplayName("Entry Fee")]
        [Precision(18, 2)]
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Whether this tournament kick off
        /// </summary>
        public bool? KickedOff { get; set; }
    }
}
