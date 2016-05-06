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
            foreach (WishlistItem item in wishlist.WishlistItems)
            {
                item.Reserved = true;
            }
        }

        public Wishlist GetOrCreateWishlist(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                Wishlist newWishlist = new Wishlist();
                ctx.Wishlists.Add(newWishlist);
                code = newWishlist.UID;
                ctx.SaveChanges();
            }
            return ctx.Wishlists.Where(w => w.UID == code).FirstOrDefault();
        }

        public void Remove(WishlistItem item)
        {
            ctx.WishlistItems.Remove(item);
            ctx.SaveChanges();
        }

        public void SaveWishlist(Wishlist wishlist)
        {
            Wishlist w = ctx.Wishlists.Where(x => x.UID == wishlist.UID).FirstOrDefault();
            ctx.SaveChanges();
        }

        public void Update(WishlistItem item)
        {
            throw new NotImplementedException();
        }
    }
}