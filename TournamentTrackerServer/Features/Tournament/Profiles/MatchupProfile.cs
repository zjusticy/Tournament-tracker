using AutoMapper;
using TournamentTracker.Features.Tournament.Models;
using TournamentTracker.Features.Tournament.Models.Dtos;

namespace TournamentTracker.Features.Tournament.Profiles
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
