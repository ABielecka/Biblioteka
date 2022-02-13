using AutoMapper;
using Biblioteka.Core;

namespace Biblioteka.View
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(c => c.RoleName, k => k.MapFrom(s => s.Role.Name));

            CreateMap<AddUserDTO, User>();

            CreateMap<UpdateUserDTO, User>();

            CreateMap<ChangePasswordDTO, User>()
                .ForMember(c => c.PasswordHash, k => k.MapFrom(dto => new User() { PasswordHash = dto.PasswordHash }));
        }
    }
}
