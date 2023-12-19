using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.Context;

namespace UltraSoundWeb.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        private static string Encrypt(string text)
        {
            using var md5 = new MD5CryptoServiceProvider();
            using var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            using (var transform = tdes.CreateEncryptor())
            {
                byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
        }
        public async Task<Entities.User> Login(LoginVM request)
        {
            var u = await _context.Users.Include(x => x.Doctor).FirstOrDefaultAsync(x => x.Username == request.Username);
            if (u == null)
                return null;
            if (u.Password == Encrypt(request.Password))
            {
                return u;
            }
            return null;
        }
    }
}
