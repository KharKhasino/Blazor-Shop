using Microsoft.EntityFrameworkCore;
using OnlineShop.Server.Data;
using OnlineShop.Server.Models;

namespace OnlineShop.Server.Repos.ProductRepo
{

    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext context;
        public ProductRepo(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public async Task<Product> AddItem(Product product)
        {
            var result = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return result.Entity;

        }

        public async void DeleteItem(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                Console.WriteLine("Item Deleted Successfully");
            }
        }

        public async Task<List<ProductCategory>> GetCategories()
        {
            var categories = await context.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await context.ProductCategories.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await context.Products.Include(p => p.ProdCategory).SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<List<Product>> GetItems()
        {
            var products = await context.Products.Include(p => p.ProdCategory).ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetItemsByCategory(int id)
        {

            var products = await context.Products.Include(p => p.ProdCategory).Where(p => p.CategoryId == id).ToListAsync();
            return products;

        }

        public async Task<bool> ProductExists(int id)
        {
            return await context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<Product> UpdateItem(int id, Product product)
        {
            var oldProd = await GetItem(id);
            if (oldProd != null)
            {
                oldProd.Name = product.Name;
                oldProd.Price = product.Price;
                oldProd.Desc = product.Desc;
                oldProd.Qty = product.Qty;
                oldProd.Img = product.Img;
                oldProd.CategoryId = product.CategoryId;
                await context.SaveChangesAsync();
                return oldProd;
            }
            return null;
        }

    }
}