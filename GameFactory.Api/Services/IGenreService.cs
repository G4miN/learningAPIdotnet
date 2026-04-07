using GameFactory.Api.Dto;

namespace GameFactory.Api.Services
{
    public interface IGenreService
    {
        Task<ICollection<GenreDto>> GetAllGenres();
        Task CreateGenre(CreateGenreDto request);
        Task DeleteGenre(int id);
        Task UpdateGenre(UpdateGenreDto request);
    }
}
