using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApp.RazorUI.Models;
using MovieApp.RazorUI.Services;

namespace MovieApp.RazorUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MovieService _movieService;

        public List<Movie> Movies { get; set; } = new();

        public IndexModel(MovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task OnGetAsync()
        {
            Movies = await _movieService.GetMoviesAsync();
        }
    }
}
