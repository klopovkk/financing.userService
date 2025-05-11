using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Abstractions
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserById(Guid id);
        public Task<ICollection<UserDTO>> GetAllUsers();
        public Task DeleteUser(Guid id);
        public Task AddUser(UserDTO user);
        public Task UpdateUser(UserDTO user);
        public Task<TokenInfoDTO> CheckLogin(string Email, string Password);

    }
}
