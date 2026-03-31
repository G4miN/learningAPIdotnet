using System.ComponentModel.DataAnnotations;

namespace GameFactory.Api.Dto;

public record GameDto
{
    public int Id { get; init; }
    [Required]
    public string Title { get; init; } = string.Empty;
    [Required]
    [StringLength(20)]
    public string Genre { get; init; } = string.Empty;
    [Range(1, 100)]
    public decimal Price { get; init; }
    public DateOnly ReleaseDate { get; init; }
}
