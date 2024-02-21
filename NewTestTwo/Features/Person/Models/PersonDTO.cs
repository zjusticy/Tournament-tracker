namespace NewTestTwo.Features.Person.Models
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string? CellPhoneNumber { get; set; }
    }
}
