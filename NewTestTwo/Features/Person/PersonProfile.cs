using AutoMapper;
using NewTestTwo.Features.Person.Models;

namespace NewTestTwo.Features.Person
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonModel, PersonDTO>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                );



            CreateMap<PersonAddDTO, PersonModel>();

            CreateMap<PersonUpdateDTO, PersonModel>();
        }
    }
}
