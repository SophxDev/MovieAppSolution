using MovieApp.API.DTOs;

namespace MovieApp.API.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieReadDto>> GetAllAsync();
        Task<MovieReadDto?> GetByIdAsync(int id);
        Task<MovieReadDto> CreateAsync(MovieCreateDto dto);
        Task<bool> UpdateAsync(int id, MovieUpdateDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
