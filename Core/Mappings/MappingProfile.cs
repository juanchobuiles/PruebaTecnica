using AutoMapper;
using Core.Entities;
using Core.UseCases.Users.Commands.CreateUser;

namespace Core.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
        }
    }
}
