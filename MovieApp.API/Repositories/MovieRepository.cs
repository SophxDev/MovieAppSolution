using Microsoft.EntityFrameworkCore;
using MovieApp.API.Data;
using MovieApp.API.Models;
using MovieApp.API.Repositories.Interfaces;
using System.Formats.Asn1;

namespace MovieApp.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();

        }
        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }


        public async Task<Movie> CreateAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Movies.AnyAsync(m => m.Id == id);
        }

        public async Task<List<Movie>> GetAllWithActorsAsync()
        {
            return await _context.Movies
                .Include(m => m.MovieActors)
                .ThenInclude(ma => ma.Actor)
                .ToListAsync();
        }

        public async Task<Movie?> GetByIdWithActorsAsync(int id)
        {
            return await _context.Movies
                .Include(m => m.MovieActors)
                .ThenInclude(ma => ma.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
