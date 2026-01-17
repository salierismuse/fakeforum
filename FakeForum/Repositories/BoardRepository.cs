using FakeForum.Data;
using Microsoft.EntityFrameworkCore;
using FakeForum.Models;

namespace FakeForum.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ApplicationDbContext _db;

        public BoardRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Board>> GetAll()
        {
            return await _db.Boards.ToListAsync();
        }

        public async Task<Board> GetById(int id)
        {
            return await _db.Boards.FindAsync(id);
        }
    }
}
