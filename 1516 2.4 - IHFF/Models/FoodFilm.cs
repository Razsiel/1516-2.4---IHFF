using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    public class FoodFilm
    {
        [Key]
        public int FoodFilmId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Event Event { get; set; }

        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}