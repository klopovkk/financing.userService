using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BLL.Abstractions;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories;
namespace BLL.Sevices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapperProfiler _mapper;
        public UserService(IMapperProfiler mapper, IUserRepository repository)
        {
            _userRepository = repository;
            _mapper = mapper;
        }
       
        public async Task AddUser(UserDTO user)
        {
            await _userRepository.Create(_mapper.Map(user)).ConfigureAwait(false);
        }
        public async Task DeleteUser(int id)
        {
            await _userRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.Get().ConfigureAwait(false);
            var UserDTOs = _mapper.Map(users);

            return UserDTOs;
        }
        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map(user);
            return dto;
        }
        public async Task UpdateUser(UserDTO user)
        {
            await _userRepository.Update(_mapper.Map(user)).ConfigureAwait(false);
        }
    }
}