using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.Context;

namespace UltraSoundWeb.Repositories.Doctor
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";

        private static string Encrypt(string text)
        {
            using var md5 = new MD5CryptoServiceProvider();
            using var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            using (var transform = tdes.CreateEncryptor())
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);
                byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
        }

        public DoctorRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddDoctor(DoctorVM doctor)
        {
            var u = new Entities.User
            {
                Username = doctor.UserName,
                Password = Encrypt(doctor.Password),
                Role = Common.Enums.ROLE.DOCTOR,
                Doctor = new Entities.Doctor
                {
                    Name = doctor.Name,
                    SpecializedId = doctor.SpecializedId
                }
            };
            await _dbContext.Users.AddAsync(u);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDoctor(long id)
        {
            var p = _dbContext.Doctors.Where(x => x.Id == id).Include(x => x.User).FirstOrDefault();
            _dbContext.Doctors.Remove(p);
            _dbContext.Users.Remove(p.User);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Entities.Doctor> GetDoctor(long id)
        {
            var p = await _dbContext.Doctors
                .Where(x => x.Id == id)
                .Include(x => x.UltraSoundResults)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            return p;
        }

        public async Task<IEnumerable<Entities.Doctor>> GetDoctors()
        {
            return await _dbContext.Doctors
                .Include(x => x.UltraSoundResults)
                .Include(x => x.User)
                .Include(x => x.Specialized)
                .ToListAsync();
        }

        public async Task UpdateDoctor(DoctorVM doctor)
        {
            var p = _dbContext.Doctors.Where(x => x.Id == doctor.Id).Include(x => x.User).FirstOrDefault();
            p.Name = doctor.Name;
            p.SpecializedId = doctor.SpecializedId;
            p.User.Username = doctor.UserName;
            if (!string.IsNullOrEmpty(doctor.Password))
            {
                p.User.Password = Encrypt(doctor.Password);
            }
            _dbContext.Users.Update(p.User);
            _dbContext.Doctors.Update(p);
            await _dbContext.SaveChangesAsync();
        }
    }
}
