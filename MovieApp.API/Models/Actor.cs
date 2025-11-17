using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.API.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        
        //Lista de MovieActores
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    }
}
