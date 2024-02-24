using TournamentTracker.Features.Person.Models;

namespace TournamentTracker.Features.Person.Services
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonModel>> GetPersonsAsync(int teamId);

        Task<PersonModel?> GetSinglePersonAsync(int teamId, int personId);

        Task AddPerson(int teamId, PersonModel person);

        Task UpdatePerson(PersonModel person);

        Task DeletePerson(PersonModel person);
    }
}
