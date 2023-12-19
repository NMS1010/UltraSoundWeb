using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UltraSoundWeb.Models;
using UltraSoundWeb.Repositories.Context;
using UltraSoundWeb.Services;

namespace UltraSoundWeb.Repositories.UltraSoundResult
{
    public class UltraSoundResultRepository : IUltraSoundResultRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUploadService _uploadService;

        public UltraSoundResultRepository(AppDbContext dbContext, IMapper mapper, IUploadService uploadService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _uploadService = uploadService;
        }

        public async Task AddUltraSoundResult(UltraSoundResultVM result)
        {
            var p = _mapper.Map<Entities.UltraSoundResult>(result);
            p.ResultImages = new List<Entities.ResultImage>();
            foreach (var item in result.ResultImages)
            {
                p.ResultImages.Add(new Entities.ResultImage
                {
                    Path = await _uploadService.SaveFile(item)
                });
            }
            await _dbContext.UltraSoundResults.AddAsync(p);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUltraSoundResult(long id)
        {
            var imgs = await _dbContext.ResultImages.Where(x => x.UltraSoundResultId == id).ToListAsync();
            foreach (var item in imgs)
            {
                _dbContext.ResultImages.Remove(item);
                await _uploadService.DeleteFile(item.Path);
            }
            var p = _dbContext.UltraSoundResults.Find(id);
            _dbContext.UltraSoundResults.Remove(p);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> ExportUltraSoundResult(long id)
        {
            var info = await _dbContext.Infos.FirstOrDefaultAsync();

            var result = await _dbContext.UltraSoundResults
                .Include(x => x.UltraSoundSample)
                .Include(x => x.DoctorSpecify)
                .Include(x => x.Patient)
                .Include(x => x.ResultImages)
                .FirstOrDefaultAsync(x => x.Id == id);

            throw new NotImplementedException();
        }

        public async Task<Entities.UltraSoundResult> GetUltraSoundResult(long id)
        {
            var p = await _dbContext.UltraSoundResults.Where(x => x.Id == id)
                .Include(x => x.UltraSoundSample)
                .Include(x => x.DoctorSpecify)
                .Include(x => x.Patient)
                .Include(x => x.ResultImages)
                .FirstOrDefaultAsync();

            return p;
        }

        public async Task<IEnumerable<Entities.UltraSoundResult>> GetUltraSoundResults()
        {
            return await _dbContext.UltraSoundResults
                .Include(x => x.UltraSoundSample)
                .Include(x => x.DoctorSpecify)
                .Include(x => x.Patient)
                .Include(x => x.ResultImages)
                .ToListAsync();
        }

        public async Task UpdateUltraSoundResult(UltraSoundResultVM result)
        {
            var p = await _dbContext.UltraSoundResults.Include(x => x.ResultImages).Where(x => x.Id == result.Id).FirstOrDefaultAsync();
            _mapper.Map(result, p);
            var paths = new List<string>();
            if (result.ResultImages != null && result.ResultImages.Count > 0)
            {
                paths = p.ResultImages.Select(x => x.Path).ToList();
                p.ResultImages = new List<Entities.ResultImage>();
                foreach (var item in result.ResultImages)
                {
                    p.ResultImages.Add(new Entities.ResultImage
                    {
                        Path = await _uploadService.SaveFile(item)
                    });
                }
            }
            _dbContext.UltraSoundResults.Update(p);
            await _dbContext.SaveChangesAsync();

            if (paths != null && paths.Count > 0)
            {
                foreach (var item in paths)
                {
                    await _uploadService.DeleteFile(item);
                }
            }
        }
    }
}
