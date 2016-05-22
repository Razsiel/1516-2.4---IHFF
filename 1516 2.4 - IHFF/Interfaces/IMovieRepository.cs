using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Interfaces
{
    public interface IMovieRepository
    {
        //IEnumerable<MoviesViewModel> GetAllMovies();
        IEnumerable<Movie> GetAllMovies();
        Airing GetAiring(int id);
        Movie GetMovie(int id);
        IEnumerable<Movie> GetMovies(int id);
    }
}
