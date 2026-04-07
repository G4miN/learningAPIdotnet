using System.ComponentModel.DataAnnotations;

namespace GameFactory.Api.Dto
{
    public class CreateGenreDto
    {
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
    }
}
