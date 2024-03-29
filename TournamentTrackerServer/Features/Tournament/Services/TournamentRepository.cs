﻿using Microsoft.EntityFrameworkCore;
using TournamentTracker.DbContexts;
using TournamentTracker.Features.Tournament.Models;

namespace TournamentTracker.Features.Tournament.Services
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly TournamentTrackerContext _context;

        public TournamentRepository(TournamentTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TournamentModel>> GetTournamentsAsync()
        {
            var tournaments = _context.Tournaments;
            return await tournaments.ToListAsync();
        }

        public async Task<TournamentModel?> GetSingleTournamentAsync(int tournamentId)
        {
            return await _context.Tournaments.Where(x => x.Id == tournamentId).Include(t => t.Prizes).Include(t => t.EnteredTeams).FirstOrDefaultAsync();
        }

        public async Task<TournamentModel?> GetSingleDraftTournamentAsync(int tournamentId)
        {
            return await _context.Tournaments.Where(x => x.Id == tournamentId).Include(t => t.Prizes).Include(t => t.EnteredTeams).FirstOrDefaultAsync();
        }

        public async Task<bool> TournamentExistsAsync(int tournamentId)
        {
            return await _context.Tournaments.AnyAsync(x => x.Id == tournamentId);
        }

        public async Task AddTournament(TournamentModel tournament)
        {
            if (tournament == null)
            {
                throw new ArgumentNullException(nameof(tournament));
            }

            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTournament(TournamentModel tournament)
        { await _context.SaveChangesAsync(); }

        public async Task DeleteTournament(TournamentModel tournament)
        {
            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
        }



        public async Task<IEnumerable<PrizeModel>> GetPrizesAsync(int tournamentId)
        {
            var prizes = _context.Prizes.Where(p => p.TournamentId == tournamentId);
            return await prizes.ToListAsync();
        }

        public async Task<PrizeModel?> GetSinglePrizeAsync(int tournamentId, int prizeId)
        {
            return await _context.Prizes.Where(x => x.TournamentId == tournamentId && x.Id == prizeId).FirstOrDefaultAsync();
        }

        public async Task AddPrize(int tournamentId, PrizeModel prize)
        {
            if (prize == null)
            {
                throw new ArgumentNullException(nameof(prize));
            }
            prize.TournamentId = tournamentId;
            _context.Prizes.Add(prize);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePrize(PrizeModel prize)
        { await _context.SaveChangesAsync(); }

        public async Task DeletePrize(PrizeModel prize)
        {
            _context.Prizes.Remove(prize);
            await _context.SaveChangesAsync();
        }




        public async Task<IEnumerable<MatchupModel>> GetMatchupsAsync(int tournamentId)
        {
            var matchups = _context.Matchups.Where(m => m.TournamentId == tournamentId);
            return await matchups.ToListAsync();
        }

        public async Task<MatchupModel?> GetSingleMatchupAsync(int tournamentId, int matchupId)
        {
            return await _context.Matchups.Where(x => x.TournamentId == tournamentId && x.Id == matchupId).Include(t => t.Entries).ThenInclude(e => e.TeamCompeting).FirstOrDefaultAsync();
        }

        public async Task AddMatchup(int tournamentId, MatchupModel matchup)
        {
            if (matchup == null)
            {
                throw new ArgumentNullException(nameof(matchup));
            }
            matchup.TournamentId = tournamentId;
            _context.Matchups.Add(matchup);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMatchup(MatchupModel matchup)
        { await _context.SaveChangesAsync(); }

        public async Task DeleteMatchup(MatchupModel matchup)
        {
            _context.Matchups.Remove(matchup);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> MatchupExistsAsync(int matchupId)
        {
            return await _context.Matchups.AnyAsync(x => x.Id == matchupId);
        }





        public async Task<IEnumerable<MatchupEntryModel>> GetMatchupEntriesAsync(int matchupId)
        {
            var matchupEntries = _context.MatchupEntries.Where(m => m.MatchupId == matchupId);
            return await matchupEntries.ToListAsync();
        }

        public async Task<MatchupEntryModel?> GetSingleMatchupEntryAsync(int matchupId, int matchupEntryId)
        {
            return await _context.MatchupEntries.Where(x => x.Id == matchupEntryId)
                .FirstOrDefaultAsync();
        }

        public async Task AddMatchupEntryForMatchup(int matchupId, MatchupEntryModel matchupEntry)
        {
            if (matchupEntry == null)
            {
                throw new ArgumentNullException(nameof(matchupEntry));
            }
            matchupEntry.MatchupId = matchupId;
            _context.MatchupEntries.Add(matchupEntry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMatchupEntry(MatchupEntryModel matchupEntry)
        { await _context.SaveChangesAsync(); }

        public async Task DeleteMatchupEntry(MatchupEntryModel matchupEntry)
        {
            _context.MatchupEntries.Remove(matchupEntry);
            await _context.SaveChangesAsync();
        }

    }
}
