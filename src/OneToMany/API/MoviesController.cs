using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneToMany.Data;
using OneToMany.Models;
using Microsoft.EntityFrameworkCore;

using OneToMany.Interfaces;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OneToMany.API
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private IMovieService _movService;
        private ICategoryService _catService;

        public MoviesController(IMovieService mov, ICategoryService cat)
        {
            _movService = mov;
            _catService = cat;
        }

        [HttpGet]
        public List<Movie> Get()
        {
            return _movService.ListMovies();
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _movService.GetMovie(id);
        }

        public IActionResult Post([FromBody]Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            } else if (movie.Id == 0)
            {
                _movService.AddMovie(movie);
                return Ok();
            } else
            {
                _movService.EditMovie(movie);
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movService.DeleteMovie(id);
            return Ok();
        }

    }
}
