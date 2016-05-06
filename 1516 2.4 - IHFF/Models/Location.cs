using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public int Capacity { get; set; }
    }
}