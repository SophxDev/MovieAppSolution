using MovieApp.API.Models;

namespace MovieApp.API.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> CreateAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(Movie movie);
        Task<bool> ExistsAsync(int id);

        Task<List<Movie>> GetAllWithActorsAsync();
        Task<Movie?> GetByIdWithActorsAsync(int id);
        
    }
}
