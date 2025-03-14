﻿using LoginUser.DTO;
using LoginUser.Model;
using LoginUser.Repository.UserRepository;
using LoginUser.Service.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginUser.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Signin")]
        public async Task<IActionResult> Signin([FromBody] UserSigninDTo userSignin)
        {
            try
            {
                var token = await _userService.Signin(userSignin);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("Signup")]
        public async Task<string> Signup([FromBody] UserDTO userDTO)
        {
            var user = await _userService.Signup(userDTO);
            return user;
        }

        [HttpGet("List")]
        [Authorize]
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
