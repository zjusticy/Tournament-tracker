using AutoMapper;
using TournamentTracker.Features.Tournament.Models;
using TournamentTracker.Features.Tournament.Models.Dtos;

namespace TournamentTracker.Features.Tournament.Profiles
{
    public class PrizeProfile : Profile
    {
        public PrizeProfile()
        {
            CreateMap<PrizeDTO, PrizeModel>();

            CreateMap<PrizeModel, PrizeDTO>();

            CreateMap<PrizeAddOrUpdateDTO, PrizeModel>();

            CreateMap<PrizeModel, PrizeAddOrUpdateDTO>();
        }
    }
}
