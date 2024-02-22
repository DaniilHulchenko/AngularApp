using AngularApp.Server.Domain.Models;
using AngularApp.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly iMovieRepository _data;

        public MovieController(iMovieRepository data)
        {
            _data = data;
        }



        // GET: api/<Movie>
        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
        {
                IEnumerable<Movie> data = await _data.GetAllMoviesAsync(); 
                return data; 

        }

        //GET api/<Movie>/5
        [HttpGet("{to}")]
        public async Task<IEnumerable<Movie>> Get(int to)
        {
            return await _data.GetFirstAsync(to);
        }

        // GET api/<Movie>/5
        [HttpGet("getslice/{from}/{to}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetSlice(int from, int to )
        {
            IEnumerable<Movie> data = await _data.GetMovieSliceAsync(from, to);
            return Ok(data);
        }

        // GET api/<Movie>/5
        //[HttpGet("{id}")]
        //public async Task<Movie> Get(string id)
        //{
        //    Movie data = await _data.GetMovieByIdAsync(id);
        //    return data;
        //}


        // DELETE api/<Movie>/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _data.DeleteMovieAsync(id);
        }

        //// POST api/<Movie>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<Movie>/5
        //[HttpPut("{id}")]
        //public void Put(string id, [FromBody] string value)
        //{
        //}
    }
}
