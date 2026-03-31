using System.ComponentModel.DataAnnotations;

namespace GameFactory.Api.Dto;

public record CreateGameDto
{
    [Required]
    [StringLength(50)]
    public string Title { get; init; } = string.Empty;

    [Required]
    public int GenreId { get; init; }
    [Range(1, 100)]
    public decimal Price { get; init; }
    public DateOnly ReleaseDate { get; init; }
}
