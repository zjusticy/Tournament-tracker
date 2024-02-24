using System.ComponentModel.DataAnnotations;
using TournamentTracker.Features.Team.Models;

namespace TournamentTracker.Features.Person.Models
{
    public class PersonModel
    {
        /// <summary>
        /// The unique identifier for the person
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the person
        /// </summary>
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The last name of the person
        /// </summary>
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// The primary email address of the person
        /// </summary>
        [MaxLength(254)]
        [MinLength(3)]
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// The primary email address of the person
        /// </summary>
        [MaxLength(15)]
        public string? CellPhoneNumber { get; set; }

        /// <summary>
        /// The unique id of the team this person joins
        /// </summary>
        public int? TeamId { get; set; }


        /// <summary>
        /// The team this person joins
        /// </summary>
        public TeamModel? Team { get; set; }
    }
}
