using System.ComponentModel.DataAnnotations;

namespace GameFactory.Api.Dto
{
    public class GenreDto
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
