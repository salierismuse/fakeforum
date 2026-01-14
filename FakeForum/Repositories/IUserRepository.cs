using FakeForum.Models;

namespace FakeForum.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser> GetByUsername(string username);
        Task<AppUser> GetByEmail(string email);

        Task<AppUser> GetById(int id);

        Task<bool> UserExists(string username);
        Task Create(AppUser user);
        Task Update(AppUser user);
        Task Delete(int id);
    }
}
