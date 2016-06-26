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

        public Wishlist GetWishlist(int UID)
        {
            Wishlist wishlist = ctx.Wishlists.FirstOrDefault(x => x.UID == UID);
            if (wishlist != null)
            {
                wishlist.WishlistItems = ctx.WishlistItems.Where(x => x.WishlistUID == UID).ToList();
                Wishlist.Instance = wishlist;
            }
            return Wishlist.Instance;
        }

        public void AddItem(WishlistItem item)
        {
            ctx.WishlistItems.Add(item);
            ctx.SaveChanges();
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
                    .Where(x => x.ItemId == item.ItemId);
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
                   .Where(x => x.ItemId == item.ItemId);
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

        public void CheckAvailability(Wishlist instance)
        {
            foreach (WishlistItem item in instance.WishlistItems)
            {
                IEnumerable<WishlistItem> reservedItems = ctx.WishlistItems.Where(x =>
                    x.ItemId == item.ItemId &&
                    x.Discriminator == item.Discriminator &&
                    x.PayedFor == true);

                if (item.Discriminator == ItemType.Movie.ToString() || item.Discriminator == ItemType.Special.ToString())
                {
                    if (reservedItems.Count() < item.Event.Location.Capacity)
                    {
                        item.Available = true;
                    }
                }
                else if (item.Discriminator == ItemType.FoodFilm.ToString())
                {
                    if (reservedItems.Count() < item.FoodFilm.Event.Location.Capacity)
                    {
                        item.Available = true;
                    }
                }
            }
        }
    }
}