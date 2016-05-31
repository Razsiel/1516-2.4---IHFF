using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Wishlist")]
    public class Wishlist
    {
        [Key]
        public string UID { get; set; }

        [Required]
        [RegularExpression(@"^[A-z0-9]+@(?:[A-z0-9]+\.)+[A-z]+$", ErrorMessage = "Vul aub een valide email in. voorbeeld: voorbeeld@email.nl")]
        public string Email { get; set; }

        [NotMapped]
        [Required]
        [StringLength(100, ErrorMessage = "Namen moeten minimaal 2 karakters bevatten", MinimumLength = 2)]
        public string Name { get; set; }

        public virtual ICollection<WishlistItem> WishlistItems { get; set; }

        private static Wishlist _instance;
        public static Wishlist Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Wishlist();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        private Wishlist()
        {
            WishlistItems = new List<WishlistItem>();
        }
    }
}