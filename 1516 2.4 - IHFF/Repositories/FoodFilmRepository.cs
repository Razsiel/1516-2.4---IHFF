using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using IHFF.Interfaces;

namespace IHFF.Repositories
{
    public class FilmFoodRepository : IFoodFilmRepository
    {
        IHFFContext context = IHFFContext.Instance;

        public void AddFoodFilm(FoodFilm foodFilm)
        {
            context.FoodFilms.Add(foodFilm);
            context.SaveChanges();
        }
    }
}