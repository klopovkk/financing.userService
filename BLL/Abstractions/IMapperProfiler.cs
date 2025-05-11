using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Models;

namespace BLL.Abstractions
{
    public interface IMapperProfiler
    {
        public User Map(UserDTO userDTO);
        public UserDTO Map(User user);
        public ICollection<User> Map(ICollection<UserDTO> userDTOs);
        public ICollection<UserDTO> Map(ICollection<User> users);
    }
}
