using OneToMany.Interfaces;

using OneToMany.Models;
using OneToMany.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneToMany.Services
{
    public class MovieService: IMovieService 
    {
        // declaration and constructor at top for ease of use. 
        private IGenericRepository _repo;
        private ICategoryService _cService;
        
        public MovieService(IGenericRepository repo, ICategoryService cService)
        {
            _repo = repo;
            _cService = cService;
        }

        // lists all movies
        public List<Movie> ListMovies()
        {
            List<Movie> movies = (from m in _repo.Query<Movie>()
                                  select new Movie
                                  {
                                      Id = m.Id,
                                      Title = m.Title,
                                      Director = m.Director,
                                      Category = m.Category
                                  }).ToList();
            return movies;
        }

        // gets a single movie
        public Movie GetMovie(int id)
        {
            Movie movie = (from m in _repo.Query<Movie>()
                           where m.Id == id
                           select new Movie
                           {
                               Id = m.Id,
                               Title = m.Title,
                               Director = m.Director,
                               Category = m.Category
                           }).FirstOrDefault();
            return movie;
        }

        // adds a movie
        public void AddMovie(Movie movie)
        {
            Category cat = _cService.GetCategoryNoMovies(movie.Category.Id);
            movie.Category = cat;

            _repo.Add(movie);
        }

        // edits movie
        public void EditMovie(Movie movie)
        {
            Category cat = _cService.GetCategoryNoMovies(movie.Category.Id);
            movie.Category = cat;

            _repo.Update(movie);
        }

        // deletes movie
        public void DeleteMovie(int id)
        {
            Movie movToDelete = GetMovie(id);
            _repo.Delete(movToDelete);
        }

    }
}
