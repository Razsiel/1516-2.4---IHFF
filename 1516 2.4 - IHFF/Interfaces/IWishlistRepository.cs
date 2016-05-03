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
        /// Get the wishlist from the database based on the paramater 'code'
        /// </summary>
        /// <param name="code">Unique identifier to find the wishlist with (format: IHFF####)</param>
        /// <returns>Wishlist object</returns>
        Wishlist GetWishlist(string code);  //READ

        /// <summary>
        /// Adds wishlist item to current wishlist
        /// </summary>
        /// <param name="item">The to-add wishlist item</param>
        void Add(WishlistItem item);        //CREATE
        void Update(WishlistItem item);     //UPDATE
        void Remove(WishlistItem item);     //DELETE
        void SaveWishlist(Wishlist wishlist);
    }
}
