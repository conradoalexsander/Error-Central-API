using AutoMapper;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ErrorCentral.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly TokenDTO _token;

        public UserService(IUserRepository repo, IMapper mapper, IOptions<TokenDTO> token)
        {
            _repo = repo;
            _mapper = mapper;
            _token = token?.Value;
        }

        public async Task<bool> Add(UserDTO user)
        {
            return await _repo.Add(user.UserName, user.Email, user.Password);
        }

        public async Task<string> Login(LoginDTO login)
        {
            var user = await _repo.Login(login.Email, login.Password);
            return GenerateToken(user);
        }

        private string GenerateToken(IdentityUser user)
        {
            if (user == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.Secret);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString())
                }),
                Issuer = _token.Issuer,
                Audience = _token.ValidAt,
                Expires = DateTime.UtcNow.AddHours(_token.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }

        public IdentityResult Update(UserIdDTO user)
        {
            var mappedUser = _mapper.Map<IdentityUser>(user);
            var updateProccess = _repo.Update(mappedUser);
            return updateProccess;
        }

        public async Task<bool> Delete(string id)
        {
            var user = await _repo.FindById(id);
            var deleteProccess = await _repo.Delete(user);
            return deleteProccess;
        }

        public List<UserIdDTO> SelectAll()
        {
            return _mapper.Map<List<UserIdDTO>>(_repo.SelectAll().Result);
        }

        public UserIdDTO FindByEmail(string email)
        {
            IdentityUser user = _repo.FindByEmail(email).Result;

            if (user != null)
            {
                UserIdDTO userWithId = new UserIdDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                };

                return userWithId;
            }

            return null;
        }
    }
}