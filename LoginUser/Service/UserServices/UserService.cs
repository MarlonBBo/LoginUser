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

        public async Task<UserModel> Signup(UserDTO userDTO)
        {
            try
            {
                var user = new UserModel()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                };

                var userCreate = await _userRepository.CreateUser(user);
                return userCreate;
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
    }
}
