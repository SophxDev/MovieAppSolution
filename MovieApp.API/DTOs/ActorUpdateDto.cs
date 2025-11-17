namespace MovieApp.API.DTOs
{
    public class ActorUpdateDto
    {
        public int Id { get; set; } // Identificar actor a actualizar (Si se quiere que el id solo este en la URL, se puede quitar del DTO)
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<int> MovieIds { get; set; } = new(); // Lista de Ids de peliculas en las que participa el actor
    }
}
