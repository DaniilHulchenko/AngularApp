using AngularApp.Server.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularApp.Server.Repositories.Interfaces;

    public interface iMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<IEnumerable<Movie>> GetFirstAsync(int i);
        Task<Movie> GetMovieByIdAsync(string id);
        Task<IEnumerable<Movie>> GetMovieSliceAsync(int from, int to);
        Task CreateMovieAsync(Movie movie);
        Task UpdateMovieAsync(string id, Movie updatedMovie);
        Task DeleteMovieAsync(string id);
}

