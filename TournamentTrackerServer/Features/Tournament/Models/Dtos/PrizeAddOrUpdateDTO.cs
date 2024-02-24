using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Features.Tournament.Models.Dtos
{
    public class PrizeAddOrUpdateDTO
    {
        /// <summary>
        /// The numeric identifier for the place (2 for the second place etc.)
        /// </summary>
        [DisplayName("Place Number")]
        [Required(ErrorMessage = "{0} is required")]
        public int PlaceNumber { get; set; }

        /// <summary>
        /// The friendly name for the place (second place, first runner up, etc)
        /// </summary>
        [DisplayName("Place Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(60, ErrorMessage = "{0} length must be less than {1}")]
        public string PlaceName { get; set; } = string.Empty;

        /// <summary>
        /// The fixed amount this place earns or zero if it is not used
        /// </summary>
        [Precision(14, 2)]
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// The number that represent the percentage of the overall take or
        /// zero if it is not used. The percentage is a fraction of 1 (so 0.5 for
        /// 50%)
        /// </summary>
        [Precision(14, 2)]
        public decimal PrizePercentage { get; set; }
    }
}
