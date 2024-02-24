using TournamentTracker.DbContexts;
using TournamentTracker.Features.Team.Models;
using TournamentTracker.Features.Tournament.Models;

namespace TournamentTracker.Features.Tournament.Services
{
    public class TournamentLogic : ITournamentLogic
    {
        // Order our list randomly of teams
        // Check if it is big enough - if not, add in byes - 2*2*2*2 - 2^4
        // Create our first round of matchups
        // Create every round after that - 8 matchups - 4 matchups - 2 matchups - 1 matchup

        private readonly TournamentTrackerContext _context;

        public TournamentLogic(TournamentTrackerContext context)
        {
            _context = context;
        }


        private List<MatchupModel> CreateRounds(ICollection<TeamModel> enteredTeams)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder((List<TeamModel>)enteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            List<MatchupModel> tournamentMatchups = new();

            List<MatchupModel> firstBatchMatchups = CreateFirstround(byes, randomizedTeams);

            foreach (var matchup in firstBatchMatchups)
            {
                tournamentMatchups.Add(matchup);
            }

            var otherMatchups = CreateOtherRounds(firstBatchMatchups, rounds);

            foreach (var otherMatchup in otherMatchups)
            {
                tournamentMatchups.Add(otherMatchup);
            }

            return tournamentMatchups;
        }

        private List<MatchupModel> CreateOtherRounds(List<MatchupModel> previousRound, int rounds)
        {
            int round = 2;
            /* List<MatchupModel> previousRound = model.Rounds[0];*/
            List<MatchupModel> matchupsResultList = new List<MatchupModel>();
            List<MatchupModel> currRound = new List<MatchupModel>();
            MatchupModel currMatchup = new MatchupModel();

            while (round <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    if (currMatchup.Entries.Count > 1)
                    {
                        currMatchup.MatchupRound = round;
                        currRound.Add(currMatchup);
                        matchupsResultList.Add(currMatchup);
                        currMatchup = new MatchupModel();
                    }
                }

                previousRound = currRound;

                currRound = new List<MatchupModel>();
                round++;
            }

            return matchupsResultList;
        }

        private List<MatchupModel> CreateFirstround(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> matchups = new();
            MatchupModel curr = new();

            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                if (byes > 0 || curr.Entries.Count > 1)
                {
                    curr.MatchupRound = 1;
                    matchups.Add(curr);
                    curr = new MatchupModel();

                    if (byes > 0)
                    {
                        byes--;
                    }
                }
            }

            return matchups;
        }

        private int NumberOfByes(int rounds, int numberOfTeams)
        {
            int totalTeams = 1;

            for (int i = 1; i < rounds; i++)
            {
                totalTeams *= 2;
            }

            return totalTeams - numberOfTeams;
        }

        private int FindNumberOfRounds(int teamCount)
        {
            int totalRounds = 1;
            int val = 2;

            while (val < teamCount)
            {
                totalRounds++;
                val *= 2;
            }

            return totalRounds;
        }

        private List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public async Task AddRounds(ICollection<TeamModel> enteredTeams, TournamentModel tournament)
        {
            List<MatchupModel> matchups = CreateRounds(enteredTeams);

            foreach (var matchup in matchups)
            {

                if (matchup == null)
                {
                    throw new ArgumentNullException(nameof(matchup));
                }
                matchup.TournamentId = tournament.Id;
                _context.Matchups.Add(matchup);
            }

            tournament.KickedOff = true;

            await _context.SaveChangesAsync();
        }
    }
}
