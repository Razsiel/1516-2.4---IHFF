using IHFF.Models;

namespace IHFF.Interfaces
{
    public interface IWishlistItemRepository
    {
        void Add(WishlistItem item);
        WishlistItem GetItem();
    }
}