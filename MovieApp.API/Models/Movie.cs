namespace MovieApp.API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!; // Non-nullable property with default value
        public string ImageUrl { get; set; } = null!;

        //lISTA DE MovieActors
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

        //public List<string> Actors { get; set; } = new();
    }
}


