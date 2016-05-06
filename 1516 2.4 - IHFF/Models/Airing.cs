﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    [Table("Airings")]
    public class Airing
    {
        public Airing() { }

        public Airing(int id, DateTime date, int movieId, int locationId, int activityType)
        {
            this.Id = id;
            this.Date = date;
            this.Movie_Id = movieId;
            this.Location_Id = locationId;
            this.ActivityTypes_Id = activityType;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Movie_Id { get; set; }
        public int Location_Id { get; set; }
        public int ActivityTypes_Id { get; set; }

        public virtual Movie Movie { get; set; }
    }
}