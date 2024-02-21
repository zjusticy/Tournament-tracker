using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewTestTwo.Features.Tournament.Models
{
    public class PrizeModel
    {
        /// <summary>
        /// The unique identifier for the prize
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The numeric identifier for the place (2 for the second place etc.)
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// The friendly name for the place (second place, first runner up, etc)
        /// </summary>
        [MaxLength(60)]
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

        /// <summary>
        /// The unique identifier for the tournament
        /// </summary>
        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }

        /// <summary>
        /// The tournament this prize blongs
        /// </summary>
        public TournamentModel Tournament { get; set; } = null!;
    }
}
