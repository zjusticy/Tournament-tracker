using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewTestTwo.Features.Person.Models
{
    public class PersonAddOrUpdateDTO
    {
        /// <summary>
        /// The first name of the person
        /// </summary>
        [DisplayName("First Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "The length of the {0} must be less than {1}")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The last name of the person
        /// </summary>
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "The length of the {0} must be less than {1}")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// The primary email address of the person
        /// </summary>
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(254, MinimumLength = 3, ErrorMessage = "The length of the {0} must be between {2} and {1}")]
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// The primary email address of the person
        /// </summary>
        [DisplayName("Cellphone  Number")]
        [StringLength(15, ErrorMessage = "The length of the {0} must be less than {1}")]
        public string? CellPhoneNumber { get; set; }
    }
}
