using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Wishlists")]
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-z0-9]+@(?:[A-z0-9]+\.)+[A-z]+$", ErrorMessage = "Vul aub een valide email in. voorbeeld: voorbeeld@email.nl")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Namen moeten minimaal 2 karakters bevatten", MinimumLength = 2)]
        public string Name { get; set; }
        public string UID { get; set; }

        public virtual ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();

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

        public Wishlist() { }
    }
}