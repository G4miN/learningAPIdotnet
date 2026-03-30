using GameFactory.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameFactory.Api.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await _gameService.GetAllGames().ConfigureAwait(false);
            return Ok(games);
        }
    }
}
