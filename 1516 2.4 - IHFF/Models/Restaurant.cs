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

        public Restaurant(int id, string name, int capacity, string address, string website, string info, string RestaurantInfo, string ContactInfo, string ReserveringInfo, string OpeningsTijdenInfo)
        {
            this.RestaurantId = id;
            this.Name = name;
            this.Capacity = capacity;
            this.Address = address;
            this.Website = website;
            this.Info = info;
            this.RestaurantInfo = RestaurantInfo;
            this.ContactInfo = ContactInfo;
            this.ReserveringInfo = ReserveringInfo;
            this.OpeningsTijdenInfo = OpeningsTijdenInfo;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantId { get; set; }
        public string Name { get; set; }

        public int Capacity { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Info { get; set; }
        public string RestaurantInfo { get; set; }
        public string ContactInfo { get; set; }
        public string ReserveringInfo { get; set; }
        public string OpeningsTijdenInfo { get; set; }
        public string Image { get; set; }
        public string ResImage1 { get; set; }
        public string ResImage2 { get; set; }
    }
}