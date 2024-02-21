using AutoMapper;
using NewTestTwo.Features.Tournament.Models;
using NewTestTwo.Features.Tournament.Models.Dtos;

namespace NewTestTwo.Features.Tournament.Profiles
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<TournamentDTO, TournamentModel>();

            CreateMap<TournamentModel, TournamentDTO>();

            CreateMap<TournamentAddDTO, TournamentModel>();

            CreateMap<TournamentModel, TournamentAddDTO>();

            CreateMap<TournamentUpdateDTO, TournamentModel>();

            CreateMap<TournamentModel, TournamentUpdateDTO>();

            CreateMap<TournamentModel, TournamentDetailDTO>();
        }
    }
}
