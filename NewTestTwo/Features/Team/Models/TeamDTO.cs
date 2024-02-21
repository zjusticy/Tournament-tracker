using System.ComponentModel.DataAnnotations;

namespace NewTestTwo.Features.Team.Models
{
    public class TeamDTO
    {
        /// <summary>
        /// The unique identifier for the match
        /// </summary
        public int Id { get; set; }

        /// <summary>
        /// The name of the team
        /// </summary>
        [MaxLength(100)]
        public string TeamName { get; set; } = string.Empty;
    }
}
