using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Interfaces;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        IHFFContext ctx = IHFFContext.Instance;

        public void AddItem(WishlistItem item)
        {
            ctx.WishlistItems.Add(item);
            ctx.SaveChanges();
        }

        public void Checkout(Wishlist wishlist)
        {
            
        }

        public Wishlist GetOrCreateWishlist(string code)
        {
            /*
            if (string.IsNullOrEmpty(code))
            {
                Wishlist newWishlist = Wishlist.Instance;
                Random rnd = new Random();
                newWishlist.UID = string.Format("IHFF{0}", rnd.Next(0, 9999));
                ctx.Wishlists.Add(newWishlist);
                ctx.SaveChanges();
            }
            Wishlist wishlist = ctx.Wishlists.Where(w => w.UID == code).FirstOrDefault();
            return wishlist;
            */

            Wishlist wishlist = Wishlist.Instance;
            wishlist.UID = "IHFF1234";
            wishlist.WishlistItems = new List<WishlistItem>();
            return wishlist;
        }

        public void Remove(Wishlist wishlist, WishlistItem wishlistItem)
        {
            
        }

        public void SaveWishlist(Wishlist wishlist)
        {
            Wishlist w = ctx.Wishlists.Where(x => x.UID == wishlist.UID).FirstOrDefault();
            ctx.SaveChanges();
        }

        public void Update(Wishlist wishlist, WishlistItem wishlistItem)
        {
            throw new NotImplementedException();
        }
    }
}