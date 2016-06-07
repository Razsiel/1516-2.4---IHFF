using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Location")]
    public class Location
    {
        public Location() { }

        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}