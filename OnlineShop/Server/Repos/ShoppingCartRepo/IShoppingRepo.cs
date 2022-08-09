using OnlineShop.Server.Models;
using OnlineShop.Shared.DTOs;

namespace OnlineShop.Server.Repos.ShoppingCartRepo
{
    public interface IShoppingRepo
    {
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto);
        Task<CartItem> DeleteItem(int id);
        Task<CartItem> GetItem(int id);
        Task<List<CartItem>> GetItems(int id);
    }
}
