﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewTestTwo.DbContexts;

#nullable disable

namespace NewTestTwo.Infrastructure.Migrations
{
    [DbContext(typeof(TournamentTrackerContext))]
    [Migration("20231218201344_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewTestTwo.Features.Person.Models.PersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CellPhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("NewTestTwo.Features.Team.Models.TeamModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("NewTestTwo.Features.Tournament.Models.MatchupEntryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MatchupId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchupId");

                    b.HasIndex("ParentId")
                        .IsUnique()
                        .HasFilter("[ParentId] IS NOT NULL");

                    b.HasIndex("TeamId");

                    b.ToTable("MatchupEntries");
                });

            modelBuilder.Entity("NewTestTwo.Features.Tournament.Models.MatchupModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MatchupRound")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Matchups");
                });

            modelBuilder.Entity("NewTestTwo.Features.Tournament.Models.PrizeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("PrizeAmount")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<decimal>("PrizePercentage")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("NewTestTwo.Features.Tournament.Models.TournamentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("EntryFee")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("KickedOff")
                        .HasColumnType("bit");

                    b.Property<string>("TournamentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("NewTestTwo.Features.Person.Models.PersonModel", b =>
                {
                    b.HasOne("NewTestTwo.Features.Team.Models.TeamModel", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NewTestTwo.Features.Team.Models.TeamModel", b =>
                {
                    b.HasOne("NewTestTwo.Features.Tournament.Models.TournamentModel", "Tournament")
                        .WithMany("EnteredTeams")
                        .HasForeignKey("TournamentId");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("NewTestTwo.Features.Tournament.Models.MatchupEntryModel", b =>
                {
                    b.HasOne("NewTestTwo.Features.Tournament.Models.MatchupModel", "Matchup")
                        .WithMany("Entries")
                        .HasForeignKey("MatchupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewTestTwo.Features.Tournament.Models.MatchupModel", "ParentMatchup")
                        .WithOne("ChildEntry")
                        .HasForeignKey("NewTestTwo.Features.Tournament.Models.MatchupEntryModel", "ParentId");

                    b.HasOne("NewTestTwo.Features.Team.Models.TeamModel", "TeamCompeting")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Matchup");

                    b.Navigation("ParentMatchup");

                    b.Navigation("TeamCompeting");
                });

            modelBuilder.Entity("NewTestTwo.Features.Tournament.Models.MatchupModel", b =>
                {
                    b.HasOne("NewTestTwo.Features.Tournament.Models.TournamentModel", "Tournament")
                        .WithMany("TournamentMatchups")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewTestTwo.Features.Team.Models.TeamModel", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Tournament");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("NewTestTwo.Features.Tournament.Models.PrizeModel", b =>
                {
                    b.HasOne("NewTestTwo.Features.Tournament.Models.TournamentModel", "Tournament")
                        .WithMany("Prizes")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("NewTestTwo.Features.Team.Models.TeamModel", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("NewTestTwo.Features.Tournament.Models.MatchupModel", b =>
                {
                    b.Navigation("ChildEntry");

                    b.Navigation("Entries");
                });

            modelBuilder.Entity("NewTestTwo.Features.Tournament.Models.TournamentModel", b =>
                {
                    b.Navigation("EnteredTeams");

                    b.Navigation("Prizes");

                    b.Navigation("TournamentMatchups");
                });
#pragma warning restore 612, 618
        }
    }
}
