using System.ComponentModel.DataAnnotations;

namespace MovieApp.API.DTOs
{
    public class MovieCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public List<int> ActorIds { get; set; } = new(); //ID de actores existentes
    }
}
