using Microsoft.AspNetCore.Components;
using OnlineShop.Client.Services;
using OnlineShop.Shared.DTOs;

namespace OnlineShop.Client.Pages
{
    public partial class ProductDetails
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductServ ProductServ { get; set; }
        [Inject]
        public IShoppingServ ShoppingCartServ { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public ProductDto Product { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductServ.GetItem(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected async Task AddItem(CartItemToAddDto cartItemToAdd)
        {
            try
            {
                var cartItem = await ShoppingCartServ.AddItem(cartItemToAdd);
                NavigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
