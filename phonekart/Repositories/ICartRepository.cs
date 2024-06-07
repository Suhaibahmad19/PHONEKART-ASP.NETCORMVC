using PHONEKART.Models;
using PHONEKART.Models.DTOs;

namespace PHONEKART.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int phoneId, int qty);
        Task<int> RemoveItem(int phoneId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout(CheckoutModel model);
    }
}
