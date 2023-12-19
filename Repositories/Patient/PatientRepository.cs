using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.Context;

namespace UltraSoundWeb.Repositories.Patient
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public PatientRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddPatient(PatientVM patient)
        {
            var p = _mapper.Map<Entities.Patient>(patient);
            await _dbContext.Patients.AddAsync(p);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePatient(long id)
        {
            var p = _dbContext.Patients.Find(id);
            _dbContext.Patients.Remove(p);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Entities.Patient> GetPatient(long id)
        {
            var p = await _dbContext.Patients.Where(x => x.Id == id).Include(x => x.Results).FirstOrDefaultAsync();

            return p;
        }

        public async Task<IEnumerable<Entities.Patient>> GetPatients()
        {
            return await _dbContext.Patients.Include(x => x.Results).ToListAsync();
        }

        public async Task UpdatePatient(PatientVM patient)
        {
            var p = await _dbContext.Patients.FindAsync(patient.Id);
            _mapper.Map(patient, p);
            _dbContext.Patients.Update(p);
            await _dbContext.SaveChangesAsync();
        }
    }
}
