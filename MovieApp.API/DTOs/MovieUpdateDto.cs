namespace MovieApp.API.DTOs
{
    public class MovieUpdateDto
    {
        public int Id { get; set; } //Identificar pelicula a actualzar (Si se quiere que el id solo este en la URL, se puede quitar del DTO)
        public string Title { get; set; } = string.Empty; //Empty string as default value
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<int> ActorIds { get; set; } = new(); //Lista de Ids de actores existentes


    }
}
