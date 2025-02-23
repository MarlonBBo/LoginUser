using LoginUser.Infra;
using LoginUser.Model;
using Microsoft.EntityFrameworkCore;

namespace LoginUser.Repository.UserRepository
{
    public class UserRepository : IUserInterface
    {
        private readonly ContextApp _context;

        public UserRepository(ContextApp context)
        {
            _context = context;
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            try
            {
                _context.Add(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserModel>> DeleteUser(int idUser)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(x => x.Id == idUser) ?? throw new InvalidOperationException("Usuário não encontrado");

                _context.Remove(user);
                await _context.SaveChangesAsync();
                var listUsers = await _context.User.ToListAsync();
                return listUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserModel>> List()
        {
            try
            {
                var users =  await _context.User.ToListAsync() ?? throw new InvalidOperationException("Não tem nenhum usuário no database!");

                return users; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
