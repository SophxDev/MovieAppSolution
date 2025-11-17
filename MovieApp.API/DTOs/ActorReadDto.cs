namespace MovieApp.API.DTOs
{
    public class ActorReadDto
    {
        public int Id { get; set; } // Identificador del actor
        public string Name { get; set; } = string.Empty; // Nombre del actor
        public string Biography { get; set; } = string.Empty; // Biografía del actor
        public string ImageUrl { get; set; } = string.Empty; // URL de la imagen del actor
        // Lista de Ids de películas en las que participa el actor
        public List<int> MovieIds { get; set; } = new();
    }
}
