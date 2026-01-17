using FakeForum.Models;

namespace FakeForum.Repositories
{
    public interface IBoardRepository
    {
        Task<List<Board>> GetAll();
        Task<Board> GetById(int id);
    }
}
