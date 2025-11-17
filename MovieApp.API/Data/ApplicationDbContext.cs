using Microsoft.EntityFrameworkCore;
using MovieApp.API.Models;

namespace MovieApp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<MovieActor> MovieActors { get; set; } = null!;// Non-nullable property with default value


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar clave compuesta de MovieActor
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            // Relación Movie -> MovieActor
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

            // Relación Actor -> MovieActor
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);
        }
    }
}
