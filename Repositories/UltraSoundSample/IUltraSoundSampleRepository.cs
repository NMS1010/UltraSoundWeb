using UltraSoundWeb.Models;

namespace UltraSoundWeb.Repositories.UltraSoundSample
{
    public interface IUltraSoundSampleRepository
    {
        Task<IEnumerable<Entities.UltraSoundSample>> GetUltraSoundSamples();

        Task<Entities.UltraSoundSample> GetUltraSoundSample(long id);

        Task AddUltraSoundSample(UltraSoundSampleVM topic);

        Task UpdateUltraSoundSample(UltraSoundSampleVM topic);

        Task DeleteUltraSoundSample(long id);
    }
}
