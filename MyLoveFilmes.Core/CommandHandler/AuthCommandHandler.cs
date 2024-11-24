using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyLoveFilmes.Core.Command;
using MyLoveFilmes.Domain.DTOs;
using MyLoveFilmes.Domain.Entities;
using MyLoveFilmes.Infra.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyLoveFilmes.Core.CommandHandler
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthResponseDTO>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;

        public AuthCommandHandler(IAuthRepository authRepository, IConfiguration configuration, IRoleRepository roleRepository)
        {
            _authRepository = authRepository;
            _configuration = configuration;
            _roleRepository = roleRepository;
        }

        public async Task<AuthResponseDTO> Handle(AuthCommand command, CancellationToken cancellationToken)
        {
            User user = await _authRepository.GetUserByEmail(command.Email);

            if (user is null)
            {
                return new AuthResponseDTO
                {
                    IsAuthenticated = false,
                    ErrorMessage = "Login ou senha incorretos."
                };
            }

            bool passwordIsValid = BCrypt.Net.BCrypt.Verify(command.Password, user.Password);


            if (!passwordIsValid)
            {
                return new AuthResponseDTO
                {
                    IsAuthenticated = false,
                    ErrorMessage = "Login ou senha incorretos."
                };
            }

            var token = await GenerateToken(user);

            return new AuthResponseDTO
            {
                IsAuthenticated = true,
                Token = token,
                Name = user.Name,
                Email = user.Email,
                Role = user.RoleId,
                ProfilePicture = user.ProfilePicture
            };
        }

        private async Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var roleName = await _roleRepository.GetRolesByIdAsync(user.RoleId);
            if (roleName != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
