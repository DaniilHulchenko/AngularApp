
using AngularApp.Server.Domain;
using AngularApp.Server.Domain.Models;
using AngularApp.Server.Repositories.Implementations;
using AngularApp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*############################# MongoDB ###########################################################*/
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<ApplicationDbContext>();

/*############################## Repositories ######################################################*/
builder.Services.AddScoped<iMovieRepository, MovieRepository>();
/*############################## localhost 4200 #######################################################*/
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200",
        builder =>
        {
            builder.WithOrigins("https://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
/*##################################################################################################*/

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 4200
app.UseCors("AllowLocalhost4200");

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
