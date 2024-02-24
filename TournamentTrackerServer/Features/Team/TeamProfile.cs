using AutoMapper;
using TournamentTracker.Features.Team.Models;

namespace TournamentTracker.Features.Team
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamDTO, TeamModel>();

            CreateMap<TeamModel, TeamDTO>();

            CreateMap<TeamAddOrUpdateDTO, TeamModel>();

            CreateMap<TeamModel, TeamAddOrUpdateDTO>();

            CreateMap<TeamModel, TeamDetailDTO>();
        }
    }
}
