using Microsoft.EntityFrameworkCore;
using TournamentTracker.DbContexts;
using TournamentTracker.Features.Person.Models;

namespace TournamentTracker.Features.Person.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TournamentTrackerContext _context;

        public PersonRepository(TournamentTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonModel>> GetPersonsAsync(int teamId)
        {
            var persons = _context.Persons.Where(x => x.TeamId == teamId);
            return await persons.ToListAsync();
        }

        public async Task<PersonModel?> GetSinglePersonAsync(int teamId, int personId)
        {
            return await _context.Persons.Where(x => x.Id == personId && x.TeamId == teamId).FirstOrDefaultAsync();
        }

        public async Task AddPerson(int teamId, PersonModel person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            person.TeamId = teamId;

            _context.Persons.Add(person);

            await _context.SaveChangesAsync();
        }

        public async Task UpdatePerson(PersonModel person)
        { await _context.SaveChangesAsync(); }

        public async Task DeletePerson(PersonModel person)
        {
            _context.Persons.Remove(person);

            await _context.SaveChangesAsync();
        }
    }
}
