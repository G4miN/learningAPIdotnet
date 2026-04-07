using GameFactory.Api.Dto;
using GameFactory.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameFactory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreDto request)
        {
            await _genreService.CreateGenre(request).ConfigureAwait(false);
            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteGenre(id).ConfigureAwait(false);
            return StatusCode(200);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var Genres = await _genreService.GetAllGenres().ConfigureAwait(false);
            return Ok(Genres);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre(UpdateGenreDto request)
        {
            await _genreService.UpdateGenre(request).ConfigureAwait(false);
            return StatusCode(204);
        }

    }
}
