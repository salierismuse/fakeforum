using FakeForum.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FakeForum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _boardRepository;

        public BoardController(IBoardRepository BoardRepository)
        {
            _boardRepository = BoardRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var boards = await _boardRepository.GetAll();
            return Ok(boards);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var board = await _boardRepository.GetById(id);
            if (board == null)
            {
                return NotFound(new { message = "Board not found" });
            }
            return Ok(board);
        }

    }

}
