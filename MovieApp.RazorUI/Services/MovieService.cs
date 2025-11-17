using System.Net.Http;
using System.Net.Http.Json;
using MovieApp.RazorUI.Models;

namespace MovieApp.RazorUI.Services
{
    public class MovieService
    {
        private readonly HttpClient _http;

        public MovieService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            try
            {
                var result =  await _http.GetFromJsonAsync<List<Movie>>("api/movie") ?? new List<Movie>();
                return result ?? new List<Movie>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener peliculas: {ex.Message}");
                return new List<Movie>();
            }
        }
    }
}
