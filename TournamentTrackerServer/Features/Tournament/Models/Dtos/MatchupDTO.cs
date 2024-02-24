namespace TournamentTracker.Features.Tournament.Models.Dtos
{
    public class MatchupDTO
    {
        /// <summary>
        /// The unique identifier for the match
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID from the database that will be used to idnetify the winner
        /// </summary>
        public int? Winner { get; set; }

        /// <summary>
        /// Which round this match is part of
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
