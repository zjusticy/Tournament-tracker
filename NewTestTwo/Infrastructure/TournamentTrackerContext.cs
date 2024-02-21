using Microsoft.EntityFrameworkCore;
using NewTestTwo.Features.Person.Models;
using NewTestTwo.Features.Team.Models;
using NewTestTwo.Features.Tournament.Models;

namespace NewTestTwo.DbContexts
{
    public class TournamentTrackerContext : DbContext
    {
        public TournamentTrackerContext(DbContextOptions<TournamentTrackerContext> options) : base(options)
        {
        }

        public DbSet<PersonModel> Persons { get; set; } = null!;

        public DbSet<TournamentModel> Tournaments { get; set; } = null!;

        public DbSet<PrizeModel> Prizes { get; set; } = null!;

        public DbSet<MatchupModel> Matchups { get; set; } = null!;

        public DbSet<MatchupEntryModel> MatchupEntries { get; set; } = null!;

        public DbSet<TeamModel> Teams { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MatchupModel>()
                        .HasMany(m => m.Entries)
                        .WithOne(me => me.Matchup)
                        .HasForeignKey(me => me.MatchupId)
                        .IsRequired();



            modelBuilder.Entity<MatchupModel>()
                        .HasOne(m => m.ChildEntry)
                        .WithOne(me => me.ParentMatchup)
                        .HasForeignKey<MatchupEntryModel>(me => me.ParentId)
                        .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
