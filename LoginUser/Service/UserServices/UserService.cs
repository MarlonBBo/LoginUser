﻿using LoginUser.DTO;
using LoginUser.Model;
using LoginUser.Repository.UserRepository;

namespace LoginUser.Service.UserServices
{
    public class UserService
    {
        private readonly IUserInterface _userRepository;
        private readonly BcryptService _bcryptService;

        public UserService(IUserInterface userRepository, BcryptService bcryptService)
        {
            _userRepository = userRepository;
            _bcryptService = bcryptService;
        }

        public async Task<UserModel> Signin(UserSigninDTo userSigninDTo)
        {
            var bcryptService = new BcryptService();

            var user = await _userRepository.VeryfyUser(userSigninDTo.Email) ?? throw new Exception("Usuário não cadastrado");
            var compare = bcryptService.VerifyPassword(userSigninDTo.Password, user.Password);

            if (compare == false)
            {
                throw new Exception("Credenciais erradas");
            }

            return user;
        }

        public async Task<string> Signup(UserDTO userDTO)
        {
            try
            {

                var bcryptService = new BcryptService();

                var password = bcryptService.HashPassword(userDTO.Password);

                var user = new UserModel()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Password = password
                };

                await _userRepository.CreateUser(user);
                return "Usuário criado(UseService)";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserModel>> List()
        {
            var listUser = await _userRepository.List();
            return listUser;
        }

        public async Task<List<UserModel>> DeleteUser(int idUser)
        {
            var user = await _userRepository.DeleteUser(idUser);
            return user;
        }
    }
}
