using BLL.Abstractions;
using BLL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var list = await _userService.GetAllUsers();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUsersId(Guid id)
        {
            try
            {
                var user = await _userService.GetUserById(id).ConfigureAwait(false);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostUsers(UserDTO user)
        {
            try
            {
                await _userService.AddUser(user).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost()]
        [Route("login")]
        public async Task<IActionResult> Login(LoginInfoDTO login)
        {
            try
            {
                var result = await _userService.CheckLogin(login.email, login.password).ConfigureAwait(false);
                return result.token == null ? Unauthorized() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutUsers(UserDTO user)
        {
            try
            {
                await _userService.UpdateUser(user).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUsers(Guid id)
        {
            try
            {
                await _userService.DeleteUser(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
