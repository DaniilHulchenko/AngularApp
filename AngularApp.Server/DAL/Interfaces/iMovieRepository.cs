using AngularApp.Server.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositories.Interfaces;

    public interface iMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(string id);
        Task CreateMovieAsync(Movie movie);
        Task UpdateMovieAsync(string id, Movie updatedMovie);
        Task DeleteMovieAsync(string id);
}

