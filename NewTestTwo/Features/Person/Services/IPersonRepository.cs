using NewTestTwo.Features.Person.Models;

namespace NewTestTwo.Features.Person.Services
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonModel>> GetPersonsAsync(int teamId);

        Task<PersonModel?> GetSinglePersonAsync(int teamId, int personId);

        void AddPerson(int teamId, PersonModel person);

        void UpdatePerson(PersonModel person);

        void DeletePerson(PersonModel person);
    }
}
