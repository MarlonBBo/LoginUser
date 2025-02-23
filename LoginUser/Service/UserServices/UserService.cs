using LoginUser.DTO;
using LoginUser.Model;
using LoginUser.Repository.UserRepository;

namespace LoginUser.Service.UserServices
{
    public class UserService
    {
        private readonly IUserInterface _userRepository;

        public UserService(IUserInterface userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Signup(UserDTO userDTO)
        {
            try
            {
                var user = new UserModel()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Password = userDTO.Password,
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
