namespace MedScheduler.Application.Services
{
    using MedScheduler.Application.Interfaces;
    using MedScheduler.Domain.Entities;
    using MedScheduler.Domain.Interfaces;
    using System.Security.Cryptography;

    public class UserService(IUserRepository _userRepository) : IUserService
    {
        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null) return null;

            if (!VerifyPassword(password, user.PasswordHash)) return null;

            return user;
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
    }

}
