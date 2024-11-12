using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO_A25460_TP
{
    internal class Login
    {
        public string Username { get; private set; }
        private string Password { get; set; }
        private int loginAttempts = 0;
        private const int maxAttempts = 3;
        public DateTime LastLoginAttempt { get; private set; }

        public Login(string username, string password)
        {
            if (!IsPasswordStrong(password))
                throw new ArgumentException("A senha deve ter ao menos 8 caracteres, incluindo maiúsculas, minúsculas, números e caracteres especiais.");

            Username = username;
            Password = HashPassword(password);
        }

        public bool Authenticate(string usernameInput, string passwordInput)
        {
            LastLoginAttempt = DateTime.Now;

            if (loginAttempts >= maxAttempts)
            {
                Console.WriteLine("Conta bloqueada temporariamente devido a múltiplas tentativas falhas.");
                return false;
            }

            if (Username == usernameInput && Password == HashPassword(passwordInput))
            {
                loginAttempts = 0;
                return true;
            }
            else
            {
                loginAttempts++;
                return false;
            }
        }

        public static bool IsPasswordStrong(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
