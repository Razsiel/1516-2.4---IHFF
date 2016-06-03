using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Interfaces
{
    public interface IWishlistRepository
    {
        /// <summary>
        /// Get the wishlist from the database based on the paramater 'code'. If code is null or empty, creates a new wishlist
        /// </summary>
        /// <param name="code">Unique identifier to find the wishlist with (format: IHFF####)</param>
        /// <returns>Wishlist object</returns>
        Wishlist GetOrCreateWishlist(string code);                      //CREATE
        Wishlist GetWishlist(string UID);                               //READ

        /// <summary>
        /// Adds wishlist item to current wishlist
        /// </summary>
        /// <param name="item">The to-add wishlist item</param>
        void AddItem(WishlistItem item);                                //CREATE
        Wishlist Checkout(Wishlist wishlist);                           //UPDATE
        void Remove(Wishlist wishlist, WishlistItem wishlistItem);      //DELETE
        Wishlist SaveWishlist(Wishlist wishlist);
    }
}
