using AutoMapper;
using Biblioteka.Core;

namespace Biblioteka.View.MappingProfile
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleDTO>()
                .ForMember(c => c.Name, k => k.MapFrom(s => s.Name));

            CreateMap<AddRoleDTO, Role>()
                //.ForMember(c => c.Name, k => k.MapFrom(dto => new Role(){Name = dto.Name}));
                .ForMember(c => c.Name, k => k.MapFrom(dto => dto.Name));

            CreateMap<UpdateRoleDTO, Role>();
        }
    }
}
