using GameFactory.Api.Dto;
using GameFactory.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameFactory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(CreateGameDto request)
        {
           await _gameService.CreateGame(request).ConfigureAwait(false);
           return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await _gameService.DeleteGame(id).ConfigureAwait(false);
            return StatusCode(200);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            //var games = await _gameService.GetAllGames().ConfigureAwait(false);
            return Ok("Franny");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGame(UpdateGameDto request)
        {
            await _gameService.UpdateGame(request).ConfigureAwait(false);
            return StatusCode(204);
        }
    }
}
