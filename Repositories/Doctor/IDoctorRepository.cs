using UltraSoundWeb.Models;

namespace UltraSoundWeb.Repositories.Doctor
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Entities.Doctor>> GetDoctors();

        Task<Entities.Doctor> GetDoctor(long id);

        Task AddDoctor(DoctorVM topic);

        Task UpdateDoctor(DoctorVM topic);

        Task DeleteDoctor(long id);
    }
}
