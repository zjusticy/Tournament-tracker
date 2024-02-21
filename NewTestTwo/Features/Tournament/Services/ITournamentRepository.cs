using NewTestTwo.Features.Tournament.Models;

namespace NewTestTwo.Features.Tournament.Services
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<TournamentModel>> GetTournamentsAsync();

        Task<TournamentModel?> GetSingleTournamentAsync(int tournamentId);

        Task<TournamentModel?> GetSingleDraftTournamentAsync(int tournamentId);

        Task<bool> TournamentExistsAsync(int tournamentId);

        void AddTournament(TournamentModel tournament);

        void UpdateTournament(TournamentModel tournament);

        void DeleteTournament(TournamentModel tournament);



        Task<IEnumerable<PrizeModel>> GetPrizesAsync(int tournamentId);

        Task<PrizeModel?> GetSinglePrizeAsync(int tournamentId, int prizeId);

        void AddPrize(int tournamentId, PrizeModel prize);

        void UpdatePrize(PrizeModel prize);

        void DeletePrize(PrizeModel prize);


        Task<IEnumerable<MatchupModel>> GetMatchupsAsync(int tournamentId);

        Task<MatchupModel?> GetSingleMatchupAsync(int tournamentId, int matchupId);

        void AddMatchup(int tournamentId, MatchupModel matchup);

        void UpdateMatchup(MatchupModel matchup);

        void DeleteMatchup(MatchupModel matchup);

        Task<bool> MatchupExistsAsync(int matchupId);




        Task<IEnumerable<MatchupEntryModel>> GetMatchupEntriesAsync(int matchupId);

        Task<MatchupEntryModel?> GetSingleMatchupEntryAsync(int matchupId, int matchupEntryId);

        void AddMatchupEntryForMatchup(int matchupId, MatchupEntryModel matchupEntry);

        void UpdateMatchupEntry(MatchupEntryModel matchupEntry);

        void DeleteMatchupEntry(MatchupEntryModel matchupEntry);
    }
}
