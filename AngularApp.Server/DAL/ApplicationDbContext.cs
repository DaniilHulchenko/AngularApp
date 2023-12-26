using AngularApp.Server.Domain;
using AngularApp.Server.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Entities;
//using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;



public class ApplicationDbContext
{
    public IMongoCollection<Movie> Movie ;

    public ApplicationDbContext(IOptions<MongoSettings> DBSettings)
    {
        var mongoClient = new MongoClient(DBSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(DBSettings.Value.DatabaseName);

        Movie = mongoDatabase.GetCollection<Movie>(
        DBSettings.Value.CollectionName);
    }
}