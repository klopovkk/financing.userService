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
        public Task<UserDTO> GetUserById(int id);
        public Task<ICollection<UserDTO>> GetAllUsers();
        public Task DeleteUser(int id);
        public Task AddUser(UserDTO user);
        public Task UpdateUser(UserDTO user);
    }
}
