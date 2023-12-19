using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.Context;

namespace UltraSoundWeb.Repositories.UltraSoundSample
{
    public class UltraSoundSampleRepository : IUltraSoundSampleRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UltraSoundSampleRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddUltraSoundSample(UltraSoundSampleVM sample)
        {
            var p = _mapper.Map<Entities.UltraSoundSample>(sample);
            await _dbContext.UltraSoundSamples.AddAsync(p);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUltraSoundSample(long id)
        {
            var p = _dbContext.UltraSoundSamples.Find(id);
            _dbContext.UltraSoundSamples.Remove(p);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Entities.UltraSoundSample> GetUltraSoundSample(long id)
        {
            var p = await _dbContext.UltraSoundSamples.Where(x => x.Id == id).Include(x => x.UltraSoundResults).FirstOrDefaultAsync();

            return p;
        }

        public async Task<IEnumerable<Entities.UltraSoundSample>> GetUltraSoundSamples()
        {
            return await _dbContext.UltraSoundSamples.Include(x => x.UltraSoundResults).ToListAsync();
        }

        public async Task UpdateUltraSoundSample(UltraSoundSampleVM sample)
        {
            var p = await _dbContext.UltraSoundSamples.FindAsync(sample.Id);
            _mapper.Map(sample, p);
            _dbContext.UltraSoundSamples.Update(p);
            await _dbContext.SaveChangesAsync();
        }
    }
}
