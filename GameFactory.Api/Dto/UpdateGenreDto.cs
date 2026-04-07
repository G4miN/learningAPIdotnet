using System.ComponentModel.DataAnnotations;

namespace GameFactory.Api.Dto
{
    public class UpdateGenreDto
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
