using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("ActivityTypes")]
    public abstract class ActivityType
    {
        public int Id { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public abstract DateTime ActivityDate { get; set; }
        [NotMapped]
        public string Image { get; set; }

        public virtual ICollection<WishlistItem> WishlistItems { get; set; }

        [NotMapped]
        public abstract string LocationString { get; }
    }
}