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

        public Wishlist Checkout(Wishlist wishlist)
        {
            //Check whether the wishlist already exists in the db
            Wishlist w = ctx.Wishlists.Where(x => x.UID == wishlist.UID).FirstOrDefault();

            // Add the wishlist to the DB if it hasn't been found
            if (w == null)
            {
                w = ctx.Wishlists.Add(wishlist);
            }

            // Iterate through all wishlistitems
            // Check whether the item has already been saved in the DB before
            // If not, then add it to the DB
            foreach (WishlistItem item in w.WishlistItems)
            {
                if (item.Selected)
                {
                    item.PayedFor = true;
                }
                IQueryable<WishlistItem> itemsInDb = ctx.WishlistItems
                   .Where(x => x.EventId == item.EventId
                   && x.Date == item.Date
                   && x.LocationId == item.LocationId);
                if (itemsInDb.Count() == 0)
                {
                    ctx.WishlistItems.Add(item);
                }
            }

            // Save entire wishlist
            ctx.SaveChanges();
            Wishlist.Instance = GetWishlist(wishlist.UID);
            return Wishlist.Instance;
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

        public Wishlist GetWishlist(string UID)
        {
            Wishlist wishlist = ctx.Wishlists.FirstOrDefault(x => x.UID == UID);
            if (wishlist != null)
            {
                wishlist.WishlistItems = ctx.WishlistItems.Where(x => x.WishlistUID == UID).ToList();
                Wishlist.Instance = wishlist;
            }
            return Wishlist.Instance;
        }

        public void Remove(Wishlist wishlist, WishlistItem wishlistItem)
        {
            Wishlist w = GetWishlist(wishlist.UID);
            wishlist.WishlistItems.Remove(wishlistItem);
            if (w.WishlistItems.Where(x => x.WishlistItemId == wishlistItem.WishlistItemId) != null)
            {
                w.WishlistItems.Remove(wishlistItem);
            }
            ctx.SaveChanges();
        }

        public Wishlist SaveWishlist(Wishlist wishlist)
        {
            //Check whether the wishlist already exists in the db
            Wishlist w = ctx.Wishlists.Where(x => x.UID == wishlist.UID).FirstOrDefault();

            // Add the wishlist to the DB if it hasn't been found
            if (w == null)
            {
                w = ctx.Wishlists.Add(wishlist);
            }

            // Iterate through all wishlistitems
            // Check whether the item has already been saved in the DB before
            // If not, then add it to the DB
            foreach (WishlistItem item in w.WishlistItems)
            {
                IQueryable<WishlistItem> itemsInDb = ctx.WishlistItems
                    .Where(x => x.EventId == item.EventId 
                    && x.Date == item.Date 
                    && x.LocationId == item.LocationId);
                if (itemsInDb.Count() == 0)
                {
                    ctx.WishlistItems.Add(item);
                }
            }

            // Save wishlist changes
            ctx.SaveChanges();
            Wishlist.Instance = GetWishlist(wishlist.UID);
            return Wishlist.Instance;
        }
    }
}