using System.Collections.Generic;
using OneToMany.Models;

namespace OneToMany.Interfaces
{
    public interface IMovieService
    {
        void AddMovie(Movie movie);
        void DeleteMovie(int id);
        void EditMovie(Movie movie);
        Movie GetMovie(int id);
        List<Movie> ListMovies();
    }
}