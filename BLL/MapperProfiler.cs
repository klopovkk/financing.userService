using BLL.Abstractions;
using BLL.DTO;
using DAL.Models;

namespace BLL;

public class MapperProfiler : IMapperProfiler
{
    public User Map(UserDTO userDTO)
    {
        var tempUser = new User();
        tempUser.Id = userDTO.Id;
        tempUser.CreatedAt = userDTO.CreatedAt;
        tempUser.Email = userDTO.Email;
        tempUser.Name = userDTO.Name;
        tempUser.Password = userDTO.Password;

        return tempUser;
    }

    public UserDTO Map(User user)
    {
        var tempUser = new UserDTO();
        tempUser.Id = user.Id;
        tempUser.CreatedAt = user.CreatedAt;
        tempUser.Email = user.Email;
        tempUser.Name = user.Name;
        tempUser.Password = user.Password;

        return tempUser;
    }

    public ICollection<UserDTO> Map(ICollection<User> users)
    {
        var userDTOs = new List<UserDTO>();

        foreach (var user in users)
        {
            var tempUser = new UserDTO();
            tempUser.Id = user.Id;
            tempUser.CreatedAt = user.CreatedAt;
            tempUser.Email = user.Email;
            tempUser.Name = user.Name;
            tempUser.Password = user.Password;
            userDTOs.Add(tempUser);
        }

        return userDTOs;
    }
    public ICollection<User> Map(ICollection<UserDTO> userDTOs)
    {
        var users = new List<User>();

        foreach (var user in userDTOs)
        {
            var tempUser = new UserDTO();
            tempUser.Id = user.Id;
            tempUser.CreatedAt = user.CreatedAt;
            tempUser.Email = user.Email;
            tempUser.Name = user.Name;
            tempUser.Password = user.Password;
            userDTOs.Add(tempUser);
        }

        return users;
    }
}