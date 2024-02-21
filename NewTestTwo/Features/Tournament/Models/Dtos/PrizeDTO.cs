using Microsoft.EntityFrameworkCore;

namespace NewTestTwo.Features.Tournament.Models.Dtos
{
    public class PrizeDTO
    {
        /// <summary>
        /// The unique identifier for the prize
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The numeric identifier for the place (2 for the second place etc.)
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// The friendly name for the place (second place, first runner up, etc)
        /// </summary>
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
