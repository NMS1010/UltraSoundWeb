using UltraSoundWeb.Models;

namespace UltraSoundWeb.Repositories.User
{
    public interface IUserRepository
    {
        Task<Entities.User> Login(LoginVM request);
    }
}
