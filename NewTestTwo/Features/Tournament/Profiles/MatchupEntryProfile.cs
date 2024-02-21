using AutoMapper;
using NewTestTwo.Features.Tournament.Models;
using NewTestTwo.Features.Tournament.Models.Dtos;

namespace NewTestTwo.Features.Tournament.Profiles
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
