using API.DTOS;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Assignment, AssignmentToReturn>()
             .ForMember(a => a.User, o => o.MapFrom(s => s.User.FirstName + " " + s.User.LastName));
        }
    }
}