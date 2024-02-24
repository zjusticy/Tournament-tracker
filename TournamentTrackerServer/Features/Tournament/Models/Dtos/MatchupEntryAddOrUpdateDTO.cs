namespace TournamentTracker.Features.Tournament.Models.Dtos
{
    public class MatchupEntryAddOrUpdateDTO
    {

        /// <summary>
        /// The unique identifier for the team
        /// </summary>
        public int? TeamId { get; set; }

        /// <summary>
        /// Represents the score of this team
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// The unique identifierr for the matchup this entry belongs
        /// </summary>
        public int? MatchupId { get; set; }


        /// <summary>
        /// The unique identifierr for the parent matchup (team)
        /// </summary>
        public int? PreviousMatchupId { get; set; }
    }
}
