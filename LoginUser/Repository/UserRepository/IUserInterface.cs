using LoginUser.DTO;
using LoginUser.Model;

namespace LoginUser.Repository.UserRepository
{
    public interface IUserInterface
    {
        Task<UserModel> CreateUser(UserModel user);
        Task<List<UserModel>> DeleteUser(int idUser);
        Task<List<UserModel>> List();
        Task<UserModel> VeryfyUser(string email);
    }
}
