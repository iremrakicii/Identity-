using Microsoft.AspNetCore.Identity;

namespace Identity_.Services
{
    public class PasswordHasherService
    {
        private readonly IPasswordHasher<string> _passwordHasher;

        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<string>();
        }

        public string HashPassword(string plainTextPassword)
        {
            return _passwordHasher.HashPassword(null, plainTextPassword);
        }

        public bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, plainTextPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}