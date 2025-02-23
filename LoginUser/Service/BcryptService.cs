using Microsoft.AspNetCore.Identity;

namespace LoginUser.Service
{
    public class BcryptService
    {
        private readonly PasswordHasher<string> _passwordHasher;

        public BcryptService()
        {
            _passwordHasher = new PasswordHasher<string>();
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
