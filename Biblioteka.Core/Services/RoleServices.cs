using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Core
{
    public interface IRoleServices
    {
        IEnumerable<RoleDTO> GetAll();
        void Add(AddRoleDTO dto);
        bool Update(string name, UpdateRoleDTO dto);
    }

    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleServices(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            var roles = _roleRepository.GetAll();
            var rolesDTO = _mapper.Map<List<RoleDTO>>(roles);
            return rolesDTO;
        }

        public void Add(AddRoleDTO dto)
        {
            var role = _mapper.Map<Role>(dto);
            _roleRepository.Add(role);
            _roleRepository.Save();
        }

        public bool Update(string name, UpdateRoleDTO dto)
        {
            var role = _roleRepository.GetAll().FirstOrDefault(c => c.Name == name);

            if (role is null) return false;

            role.Name = dto.Name;
            _roleRepository.Save();

            return true;
        }
    }
}
