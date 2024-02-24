using TournamentTracker.Features.Tournament.Models;

namespace TournamentTracker.Features.Tournament.Services
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<TournamentModel>> GetTournamentsAsync();

        Task<TournamentModel?> GetSingleTournamentAsync(int tournamentId);

        Task<TournamentModel?> GetSingleDraftTournamentAsync(int tournamentId);

        Task<bool> TournamentExistsAsync(int tournamentId);

        Task AddTournament(TournamentModel tournament);

        Task UpdateTournament(TournamentModel tournament);

        Task DeleteTournament(TournamentModel tournament);



        Task<IEnumerable<PrizeModel>> GetPrizesAsync(int tournamentId);

        Task<PrizeModel?> GetSinglePrizeAsync(int tournamentId, int prizeId);

        Task AddPrize(int tournamentId, PrizeModel prize);

        Task UpdatePrize(PrizeModel prize);

        Task DeletePrize(PrizeModel prize);


        Task<IEnumerable<MatchupModel>> GetMatchupsAsync(int tournamentId);

        Task<MatchupModel?> GetSingleMatchupAsync(int tournamentId, int matchupId);

        Task AddMatchup(int tournamentId, MatchupModel matchup);

        Task UpdateMatchup(MatchupModel matchup);

        Task DeleteMatchup(MatchupModel matchup);

        Task<bool> MatchupExistsAsync(int matchupId);




        Task<IEnumerable<MatchupEntryModel>> GetMatchupEntriesAsync(int matchupId);

        Task<MatchupEntryModel?> GetSingleMatchupEntryAsync(int matchupId, int matchupEntryId);

        Task AddMatchupEntryForMatchup(int matchupId, MatchupEntryModel matchupEntry);

        Task UpdateMatchupEntry(MatchupEntryModel matchupEntry);

        Task DeleteMatchupEntry(MatchupEntryModel matchupEntry);
    }
}
