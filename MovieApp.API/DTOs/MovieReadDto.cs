namespace MovieApp.API.DTOs
{
    public class MovieReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public List<string> Actors { get; set; } = new(); //Nombres de actores
        //public List<string> Actors { get; set; } = new();
    }
}