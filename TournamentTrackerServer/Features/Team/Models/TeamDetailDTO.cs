using System.ComponentModel.DataAnnotations;
using TournamentTracker.Features.Person.Models;

namespace TournamentTracker.Features.Team.Models
{
    public class TeamDetailDTO
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

        /// <summary>
        /// List of members of this team
        /// </summary>
        public ICollection<PersonDTO> TeamMembers { get; set; } = new List<PersonDTO>();
    }
}
