using OnlineShop.Server.Models;

namespace OnlineShop.Server.Repos.ProductRepo
{
    public interface IProductRepo
    {
        Task<List<Product>> GetItems();
        Task<List<ProductCategory>> GetCategories();
        Task<Product> GetItem(int id);
        Task<ProductCategory> GetCategory(int id);
        Task<List<Product>> GetItemsByCategory(int id);
        Task<Product> AddItem(Product product);
        Task<Product> UpdateItem(int id, Product product);
        void DeleteItem(int id);

        Task<bool> ProductExists(int id);
    }
}
