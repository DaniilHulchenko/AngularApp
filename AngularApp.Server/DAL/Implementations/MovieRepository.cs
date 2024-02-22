using AngularApp.Server.Domain.Models;
using AngularApp.Server.Repositories.Interfaces;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using AngularApp.Server.Domain;
using MongoDB.Entities;
using MongoDB.Bson;

namespace AngularApp.Server.Repositories.Implementations;

public class MovieRepository : iMovieRepository
{
    private readonly ApplicationDbContext _db;

    //private readonly IMongoCollection<Movie> _movies;

    public MovieRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        return await _db.Movie.FindAsync(_=>true).Result.ToListAsync();
    }

    public async Task<Movie> GetMovieByIdAsync(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<Movie>.Filter.Eq("_id", objectId);
        return await _db.Movie.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateMovieAsync(Movie movie)
    {
        await _db.Movie.InsertOneAsync(movie);
    }

    public async Task UpdateMovieAsync(string id, Movie updatedMovie)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<Movie>.Filter.Eq("_id", objectId);
        var updateDefinition = Builders<Movie>.Update
            .Set(m => m.Title, updatedMovie.Title)
            .Set(m => m.Director, updatedMovie.Director)
            .Set(m => m.ReleaseYear, updatedMovie.ReleaseYear)
            .Set(m => m.Genre, updatedMovie.Genre)
            .Set(m => m.Actors, updatedMovie.Actors)
            .Set(m => m.Country, updatedMovie.Country)
            .Set(m => m.DurationMinutes, updatedMovie.DurationMinutes)
            .Set(m => m.IsReleased, updatedMovie.IsReleased)
            .Set(m => m.Rating, updatedMovie.Rating)
            .Set(m => m.Slug, updatedMovie.Slug)
            .Set(m => m.Image, updatedMovie.Image)
            .Set(m => m.Description, updatedMovie.Description)
            .Set(m => m.Watched, updatedMovie.Watched);

        await _db.Movie.UpdateOneAsync(filter, updateDefinition);
    }

    public async Task DeleteMovieAsync(string id)
    {
        var objectId = new ObjectId(id);
        var filter = Builders<Movie>.Filter.Eq("_id", objectId);
        await _db.Movie.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<Movie>> GetMovieSliceAsync(int from, int to)
    {
        IEnumerable<Movie> all_data = await _db.Movie.FindAsync(_ => true).Result.ToListAsync();
        IEnumerable<Movie> data = all_data.Skip(from).Take(to);
        return data;
    }

    public async Task<IEnumerable<Movie>> GetFirstAsync(int i)
    {
        return (await _db.Movie.FindAsync(_ => true).Result.ToListAsync()).Take(i);
    }
}
