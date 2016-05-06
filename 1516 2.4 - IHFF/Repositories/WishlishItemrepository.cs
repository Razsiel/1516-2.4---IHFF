using System;
using IHFF.Interfaces;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class WishlishItemrepository : IWishlistItemRepository
    {
        private IHFFContext context = IHFFContext.Instance;

        public void Add(WishlistItem item)
        {
            context.WishlistItems.Add(item);
        }

        public WishlistItem GetItem()
        {
            throw new NotImplementedException();
        }
    }
}