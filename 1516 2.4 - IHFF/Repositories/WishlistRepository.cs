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

        public void Add(WishlistItem item)
        {
            ctx.WishlistItems.Add(item);
            item.Wishlist.WishlistItems.Add(item);
            ctx.SaveChanges();
        }

        public Wishlist GetWishlist(string code)
        {
            return ctx.Wishlists.Where(w => w.UID == code).FirstOrDefault();
        }

        public void Remove(WishlistItem item)
        {
            ctx.WishlistItems.Remove(item);
            ctx.SaveChanges();
        }

        public void SaveWishlist(Wishlist wishlist)
        {
            throw new NotImplementedException();
        }

        public void Update(WishlistItem item)
        {
            throw new NotImplementedException();
        }
    }
}