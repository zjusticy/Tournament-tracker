using AutoMapper;
using TournamentTracker.Features.Tournament.Models;
using TournamentTracker.Features.Tournament.Models.Dtos;

namespace TournamentTracker.Features.Tournament.Profiles
{
    public class MatchupEntryProfile : Profile
    {
        public MatchupEntryProfile()
        {
            CreateMap<MatchupEntryDTO, MatchupEntryModel>();

            CreateMap<MatchupEntryModel, MatchupEntryDTO>();

            CreateMap<MatchupEntryAddDTO, MatchupEntryModel>();

            CreateMap<MatchupEntryUpdateDTO, MatchupEntryModel>();
        }
    }
}
