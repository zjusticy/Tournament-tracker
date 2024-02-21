using AutoMapper;
using NewTestTwo.Features.Tournament.Models;
using NewTestTwo.Features.Tournament.Models.Dtos;

namespace NewTestTwo.Features.Tournament.Profiles
{
    public class MatchupProfile : Profile
    {
        public MatchupProfile()
        {
            CreateMap<MatchupDTO, MatchupModel>();

            CreateMap<MatchupModel, MatchupDTO>();

            CreateMap<MatchupModel, MatchupDetailDTO>();

            CreateMap<MatchupAddDTO, MatchupModel>();

            CreateMap<MatchupUpdateDTO, MatchupModel>();
        }
    }
}
