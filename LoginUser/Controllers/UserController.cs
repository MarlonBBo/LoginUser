using LoginUser.DTO;
using LoginUser.Model;
using LoginUser.Repository.UserRepository;
using LoginUser.Service.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace LoginUser.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Signup")]
        public async Task<string> Signup(UserDTO userDTO)
        {
            var user = await _userService.Signup(userDTO);
            return user;
        }

        [HttpGet("List")]
        public async Task<List<UserModel>> List()
        {
            var users = await _userService.List();
            return users;
        }

        [HttpDelete("DeleteUser")]
        public async Task<List<UserModel>> DeleteUser(int idUser)
        {
            var user = await _userService.DeleteUser(idUser);
            return user;
        }
    }
}
