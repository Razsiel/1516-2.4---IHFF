using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        public Restaurant() { }

        public Restaurant(int id, string name, int capacity, string address, string website, string info )
        {
            this.Id = id;
            this.Name = name;
            this.Capacity = capacity;
            this.Address = address;
            this.Website = website;
            this.Info = info;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Capacity { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Info { get; set; }

    }
}