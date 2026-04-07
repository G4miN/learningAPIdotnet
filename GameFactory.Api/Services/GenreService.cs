using GameFactory.Api.Dto;
using GameFactory.Api.Models;
using GameFactory.Api.Repository;

namespace GameFactory.Api.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task CreateGenre(CreateGenreDto request)
        {
            var game = new Genre
            {
                Name = request.Name,
            };
            await _genreRepository.CreateAsync(game).ConfigureAwait(false);
        }

        public async Task DeleteGenre(int id)
        {
            var game = _genreRepository.GetAsync(x => x.Id == id).Result;
            if (game != null)
            {
                await _genreRepository.RemoveAsync(game);
            }
        }

        public async Task<ICollection<GenreDto>> GetAllGenres()
        {
            var games = await _genreRepository.GetAllAsync().ConfigureAwait(false);

            return games.Select(g => new GenreDto
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }

        public async Task UpdateGenre(UpdateGenreDto request)
        {
            var game = await _genreRepository.GetAsync(x => x.Id == request.Id)
      .ConfigureAwait(false);

            if (game is null) return;

            game.Name = request.Name;

            await _genreRepository.Update(game).ConfigureAwait(false);
        }
    }
}
