using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IHFF.Helpers;

namespace IHFF.Models
{
    [Table("Event")]
    public class Event
    {
        private const decimal SPECIALPRICE = 7.50m;

        public Event() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public string Discriminator { get; set; }
        
        public virtual Location Location { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Special Special { get; set; }

        public ICollection<WishlistItem> WishlistItems { get; set; }

        [NotMapped]
        public string AiringString
        {
            get
            {
                if (Location != null)
                {
                    return string.Format("{0}, {1}-{2}, {3}", Globals.CurrentCulture.DateTimeFormat.GetDayName(Date.DayOfWeek), 
                        DateTimeHelper.Round(Date).ToString("HH:mm"),
                        DateTimeHelper.Round((Date.Add((Movie).Duration))).ToString("HH:mm"), LocationString);
                }
                return null;
            }
        }

        [NotMapped]
        public string EndTime
        {
            get
            {
                if(Location != null)
                {
                    return DateTimeHelper.Round((Date.Add((Movie).Duration))).ToString("HH:mm");
                }
                return null;
            }
        }

        [NotMapped]
        public string DayName
        {
            get
            {
                if (Location != null){
                    return Globals.CurrentCulture.DateTimeFormat.GetDayName(Date.DayOfWeek);
                }
                return null;
            }
        }

        [NotMapped]
        public string LocationString
        {
            get
            {
                if (Location != null)
                {
                    return string.Format("{0}, {1}", Location.Name, Location.Room);
                }
                return null;
            }
        }

        public ItemType GetItemType()
        {
            switch (this.Discriminator)
            {
                default:
                case "Movie":
                    return ItemType.Movie;
                case "Special":
                    return ItemType.Special;
            }
        }

        public decimal GetPrice()
        {
            switch (GetItemType())
            {
                case ItemType.Movie:
                    return Movie.Price;
                case ItemType.Special:
                    return SPECIALPRICE;
                default:
                    return 0;
            }
        }

        public string GetName()
        {
            switch (GetItemType())
            {
                case ItemType.Movie:
                    return Movie.Title;
                case ItemType.Special:
                    return Special.Name;
                default:
                    return "";
            }
        }

        public string GetImage()
        {
            switch (GetItemType())
            {
                case ItemType.Movie:
                    return Movie.Image;
                default:
                case ItemType.Special:
                    return "";
            }
        }
    }
}