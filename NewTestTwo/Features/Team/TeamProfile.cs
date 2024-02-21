using AutoMapper;
using NewTestTwo.Features.Team.Models;

namespace NewTestTwo.Features.Team
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
