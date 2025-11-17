using MovieApp.API.Models;

namespace MovieApp.API.Repositories.Interfaces
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetByIdsAsync(List<int> ids);

        //Listar todos los actores
        Task<List<Actor>> GetAllAsync();
        Task<Actor?> GetByIdAsync(int id);
        Task<Actor> CreateAsync(Actor actor);
        Task UpdateAsync(Actor actor);
        Task DeleteAsync(Actor actor);
        Task<bool> ExistsAsync(int id);

        Task<List<Actor>> GetAllWithMoviesAsync();
        Task<Actor?> GetByIdWithMoviesAsync(int id);
    }
}
