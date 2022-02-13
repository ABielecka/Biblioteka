using AutoMapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Permissions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Biblioteka.Core
{
    public interface IUserServices
    {
        ICollection<UserDTO> GetAll();
        bool Add(AddUserDTO dto);
        bool ChangePassword(string email, ChangePasswordDTO dto);
        string GenerateJwt(LoginUserDTO dto);
    }

    public class UserServices : IUserServices
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserServices(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public ICollection<UserDTO> GetAll()
        {
            var users = _userRepository.GetAll();
            var usersDTO = _mapper.Map<List<UserDTO>>(users);
            return usersDTO;
        }

        public bool Add(AddUserDTO dto)
        {
            var user = _mapper.Map<User>(dto);
            var roles = _roleRepository.GetAll().FirstOrDefault(c => c.Name.ToUpper().Equals(dto.RoleName.ToUpper()));

            if (roles == null) throw new Exception("Brak roli.");

            user.Role = roles;

            var hashPassword = _passwordHasher.HashPassword(user, dto.PasswordHash);
            user.PasswordHash = hashPassword;

            _userRepository.Add(user);
            _userRepository.Save();
            return true;
        }


        public bool ChangePassword(string email, ChangePasswordDTO dto)
        {
            var user = _userRepository.GetAll().FirstOrDefault(c => c.Email == email);

            if (user is null) return false;

            user.PasswordHash = dto.PasswordHash;
            _userRepository.Save();

            return true;
        }

        public string GenerateJwt(LoginUserDTO dto)
        {
            var user = _userRepository.GetAll().FirstOrDefault(c => c.Email.ToUpper().Equals(dto.Email.ToUpper()));
            if (user is null) throw new CredentialsInvalidException("Invalid username or password");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed) throw new CredentialsInvalidException("Invalid username or password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(_authenticationSettings.JwtExpireMinutes);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer,
                claims, expires: expires, signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
