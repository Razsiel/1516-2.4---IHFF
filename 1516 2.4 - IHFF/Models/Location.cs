using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Locations")]
    public class Location
    {
        public Location() { }

        public Location(int id, string name, string room, int capacity)
        {
            this.Id = id;
            this.Name = name;
            this.Room = room;
            this.Capacity = capacity;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Airing> Airings { get; set; }
    }
}