using OnlineShop.Shared.DTOs;

namespace OnlineShop.Client.Services
{
    public interface IProductServ
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItem(int id);
        Task<ProductDto> SaveItem(ProductDto product);
        Task<ProductDto> UpdateItem(int id, ProductDto product);
    }
}
