using MovieApp.API.DTOs;

namespace MovieApp.API.Services.Interfaces
{
    public interface IActorService
    {

        Task<List<ActorReadDto>> GetAllAsync();
        Task<ActorReadDto?> GetByIdAsync(int id);
        Task<ActorReadDto> CreateAsync(ActorCreateDto dto);
        Task<bool> UpdateAsync(int id, ActorUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
