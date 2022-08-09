using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OnlineShop.Client.Services;
using OnlineShop.Shared.DTOs;

namespace OnlineShop.Client.Pages
{
    public partial class ShoppingCart
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        [Inject]
        public IShoppingServ ShoppingCartServ { get; set; }
        public List<CartItemDto> ShoppingCartItems { get; set; }
        protected string TotalPrice { get; set; }
        protected int TotalQty { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                //ShoppingCartItems = await ShoppingCartServ.GetItems(ManUser.UserId);
                CalculateCart();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void UpdateCartPrice(CartItemDto cartItemDto)
        {
            var item = GetCartItem(cartItemDto.Id);
            if (item != null)
            {
                item.TotalPrice = cartItemDto.Price * cartItemDto.Qty;
            }
        }

        private void CalculateCart()
        {
            SetPrice();
            SetQty();
        }
        private void SetPrice()
        {
            TotalPrice = ShoppingCartItems.Sum(p => p.TotalPrice).ToString("C");
        }
        private void SetQty()
        {
            TotalQty = ShoppingCartItems.Sum(p => p.Qty);
        }

        protected async Task Update_Inp(int id)
        {
            await UpdateBtn(id, true);
        }
        private async Task UpdateBtn(int id, bool visible)
        {
            await Js.InvokeVoidAsync("HandleInput", id, visible);
        }

        private CartItemDto GetCartItem(int id)
        {
            return ShoppingCartItems.FirstOrDefault(s => s.Id == id);
        }
        protected async Task DeleteCartItem(int id)
        {
            var cartItem = await ShoppingCartServ.DeleteItem(id);
            RemoveCartItem(id);
            CalculateCart();

        }


        private void RemoveCartItem(int id)
        {
            var cartItem = GetCartItem(id);
            ShoppingCartItems.Remove(cartItem);
        }

        protected async Task UpdateCartItem(int id, int Qty)
        {
            try
            {
                if (Qty > 0)
                {
                    var updateItem = new CartItemQtyUpdateDto
                    {
                        CartId = id,
                        Qty = Qty,
                    };

                    var returnedUpdate = await ShoppingCartServ.UpdateItem(updateItem);

                    UpdateCartPrice(returnedUpdate);

                    CalculateCart();
                    await UpdateBtn(id, false);

                }
                else
                {
                    var item = ShoppingCartItems.FirstOrDefault(i => i.Id == id);
                    if (item != null)
                    {
                        item.Qty = 1;
                        item.TotalPrice = item.Price;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
