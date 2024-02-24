using AutoMapper;
using TournamentTracker.Features.Tournament.Models;
using TournamentTracker.Features.Tournament.Models.Dtos;

namespace TournamentTracker.Features.Tournament.Profiles
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
