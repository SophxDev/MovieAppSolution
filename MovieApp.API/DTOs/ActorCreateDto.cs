using System.ComponentModel.DataAnnotations;

namespace MovieApp.API.DTOs
{
    public class ActorCreateDto
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Biography { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public List<int> MovieIds { get; set; } = new(); // Lista de Ids de peliculas en las que participa el actor
    }
}
