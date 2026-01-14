using FakeForum.Data;
using Microsoft.EntityFrameworkCore;
using FakeForum.Models;

namespace FakeForum.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<AppUser> GetByUsername(string username)
        {
            return await _db.AppUsers.FirstOrDefaultAsync(u => u.Username == username);
        }
        
        public async Task<AppUser> GetByEmail(string email)
        {
            return await _db.AppUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<AppUser> GetById(int id)
        {
            return await _db.AppUsers.FindAsync(id);
        }

        public async Task<bool> UserExists(string username)
        {
            return await _db.AppUsers.AnyAsync(u => u.Username == username);
        }   

        public async Task Create(AppUser user)
        {
            _db.AppUsers.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task Update(AppUser user)
        {
            _db.AppUsers.Update(user);
            await _db.SaveChangesAsync();
        }   

        public async Task Delete(int id)
        {
            var user = await GetById(id);
            if (user != null)
            {
                _db.AppUsers.Remove(user);
                await _db.SaveChangesAsync();
            }
        }

    }
}
