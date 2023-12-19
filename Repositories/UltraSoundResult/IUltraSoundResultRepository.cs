using UltraSoundWeb.Models;

namespace UltraSoundWeb.Repositories.UltraSoundResult
{
    public interface IUltraSoundResultRepository
    {
        Task<IEnumerable<Entities.UltraSoundResult>> GetUltraSoundResults();

        Task<Entities.UltraSoundResult> GetUltraSoundResult(long id);

        Task AddUltraSoundResult(UltraSoundResultVM topic);

        Task UpdateUltraSoundResult(UltraSoundResultVM topic);

        Task DeleteUltraSoundResult(long id);

        Task<string> ExportUltraSoundResult(long id);
    }
}
