﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovie(int id);
        IEnumerable<Movie> GetMovies(int id);
    }
}
