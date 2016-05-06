using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class MoviesViewModel
    {
        public MoviesViewModel() { }

        public MoviesViewModel(int id, string image, string title, string description, string director, Int16 yearOfRelease, decimal price, List<AiringItem> airings)
        {
            this.Id = id;
            this.Image = image;
            this.Title = title;
            this.Description = description;
            this.Director = director;
            this.YearOfRelease = yearOfRelease;
            this.Price = price;
            this.Airings = airings;
        }

        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public Int16 YearOfRelease { get; set; }
        public decimal Price { get; set; }
        public List<AiringItem> Airings { get; set; }
    }
}