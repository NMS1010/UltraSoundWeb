using UltraSoundWeb.Models;

namespace UltraSoundWeb.Repositories.Patient
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Entities.Patient>> GetPatients();

        Task<Entities.Patient> GetPatient(long id);

        Task AddPatient(PatientVM topic);

        Task UpdatePatient(PatientVM topic);

        Task DeletePatient(long id);
    }
}
