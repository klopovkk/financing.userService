using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BLL.Abstractions;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
namespace BLL.Sevices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapperProfiler _mapper;
        private readonly IConfiguration _config;

        public UserService(IMapperProfiler mapper, IUserRepository repository, IConfiguration config)
        {
            _userRepository = repository;
            _mapper = mapper;
            _config = config;
        }

        public async Task AddUser(UserDTO user)
        {
            await _userRepository.Create(_mapper.Map(user)).ConfigureAwait(false);
        }
        public async Task DeleteUser(Guid id)
        {
            await _userRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.Get().ConfigureAwait(false);
            var UserDTOs = _mapper.Map(users);

            return UserDTOs;
        }
        public async Task<UserDTO> GetUserById(Guid id)
        {
            var user = await _userRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map(user);
            return dto;
        }
        public async Task<TokenInfoDTO> CheckLogin(string Email, string Password)
        {
            Expression<Func<User, bool>> filter = x => x.Email == Email;
            var result = await _userRepository.Get(filter);
            var user = _mapper.Map(result.FirstOrDefault());
            if (user == null)
            {
                return new TokenInfoDTO(Guid.Empty, null);
            }
            else if (user.Password != Password)
            {
                return new TokenInfoDTO(Guid.Empty, null);
            }
            else
            {
                var token =  AuthService.GenerateJSONWebToken(_config, user.Id);
                return new TokenInfoDTO(user.Id, token);
            }
        }
        public async Task UpdateUser(UserDTO user)
        {
            await _userRepository.Update(_mapper.Map(user)).ConfigureAwait(false);
        }
    }
}