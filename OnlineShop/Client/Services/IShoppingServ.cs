using OnlineShop.Shared.DTOs;

namespace OnlineShop.Client.Services
{
    public interface IShoppingServ
    {
        Task<List<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAdd);
        Task<CartItemDto> DeleteItem(int id);
        Task<CartItemDto> UpdateItem(CartItemQtyUpdateDto cartItemQtyUpdate);
    }
}
