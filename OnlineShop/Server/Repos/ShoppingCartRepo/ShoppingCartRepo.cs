using Microsoft.EntityFrameworkCore;
using OnlineShop.Server.Data;
using OnlineShop.Server.Models;
using OnlineShop.Shared.DTOs;

namespace OnlineShop.Server.Repos.ShoppingCartRepo
{
    public class ShoppingCartRepo : IShoppingRepo
    {
        private readonly ApplicationDbContext context;

        public ShoppingCartRepo(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await this.context.CartItems.AnyAsync(c => c.CartId == cartId &&
                                                                     c.ProductId == productId);

        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in this.context.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Qty = cartItemToAddDto.Qty
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await this.context.CartItems.AddAsync(item);
                    await this.context.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await context.CartItems.FindAsync(id);

            if (item != null)
            {
                context.CartItems.Remove(item);
                await context.SaveChangesAsync();
            }

            return item;
        }

        public async Task<CartItem> GetItem(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await (from cart in context.Carts
                          join CartItem in context.CartItems on cart.Id equals CartItem.CartId
                          where CartItem.Id == id
                          select new CartItem
                          {
                              Id = cart.Id,
                              ProductId = CartItem.ProductId,
                              Qty = CartItem.Qty,
                              CartId = CartItem.CartId
                          }).SingleOrDefaultAsync();
        }

        public async Task<List<CartItem>> GetItems(int userId)
        {
            return await (from cart in context.Carts
                          join cartItem in context.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            var item = await context.CartItems.FindAsync(id);

            if (item != null)
            {
                item.Qty = cartItemQtyUpdateDto.Qty;
                await context.SaveChangesAsync();
                return item;
            }

            return null;
        }
    }
}
