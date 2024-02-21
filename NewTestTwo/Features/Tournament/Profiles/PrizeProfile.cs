using AutoMapper;
using NewTestTwo.Features.Tournament.Models;
using NewTestTwo.Features.Tournament.Models.Dtos;

namespace NewTestTwo.Features.Tournament.Profiles
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
