using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SPP.Core.Models;

namespace SPP.Core.Services
{
    public class AuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }
            return user;
        }

        public async Task<bool> RegisterAsync(User user, string password)
        {
            if (await _userRepository.GetByUsernameAsync(user.Username) != null)
            {
                return false; // User already exists
            }

            user.PasswordHash = HashPassword(password);
            await _userRepository.AddAsync(user);
            return true;
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            // Implement password verification logic
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        private string HashPassword(string password)
        {
            // Implement password hashing logic
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}