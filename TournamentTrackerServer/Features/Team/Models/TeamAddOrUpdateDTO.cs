using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TournamentTracker.Features.Team.Models
{
    public class TeamAddOrUpdateDTO
    {

        /// <summary>
        /// The name of the team
        /// </summary>
        [DisplayName("Team Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "The length of the {0} must be less than {1}")]
        public string TeamName { get; set; } = string.Empty;
    }
}
