using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewTestTwo.Features.Person.Models;
using NewTestTwo.Features.Tournament.Models;

namespace NewTestTwo.Features.Team.Models
{
    public class TeamModel
    {
        /// <summary>
        /// The unique identifier for the match
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the team
        /// </summary>
        [MaxLength(100)]
        public string TeamName { get; set; } = string.Empty;

        /// <summary>
        /// List of members of this team
        /// </summary>
        public ICollection<PersonModel> TeamMembers { get; } = new List<PersonModel>();

        /// <summary>
        /// The unique identifier for the Tournament
        /// </summary>
        [ForeignKey(nameof(Tournament))]
        public int? TournamentId { get; set; }

        /// <summary>
        /// The Tournament this matchup belongs
        /// </summary>
        public TournamentModel? Tournament { get; set; }

    }
}
