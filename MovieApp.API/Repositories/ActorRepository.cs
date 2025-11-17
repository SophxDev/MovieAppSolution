using Microsoft.EntityFrameworkCore;
using MovieApp.API.Data;
using MovieApp.API.Models;
using MovieApp.API.Repositories.Interfaces;

namespace MovieApp.API.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<List<Actor>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Actors
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<Actor?> GetByIdAsync(int id)
        {
            return await _context.Actors.FindAsync(id);
        }

        public async Task<Actor> CreateAsync(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task UpdateAsync(Actor actor)
        {
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Actor actor)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Actors.AnyAsync(a => a.Id == id);
        }

        public async Task<List<Actor>> GetAllWithMoviesAsync()
        {
            return await _context.Actors
                .Include(a => a.MovieActors)
                .ToListAsync();
        }

        public async Task<Actor?> GetByIdWithMoviesAsync(int id)
        {
            return await _context.Actors
                .Include(a => a.MovieActors)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

    }
}
