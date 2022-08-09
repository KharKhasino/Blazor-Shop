using Microsoft.AspNetCore.Components;
using OnlineShop.Client.Services;
using OnlineShop.Shared.DTOs;

namespace OnlineShop.Client.Pages
{
    public partial class Products
    {
        [Inject]
        public IProductServ? ProductServ { get; set; }
        [Inject]
        public IShoppingServ? ShoppingCartServ { get; set; }
        public IEnumerable<ProductDto> ProductDtos { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ProductDtos = await ProductServ.GetItems();
        }

        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
        {
            return from product in ProductDtos
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }

        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDto)
        {
            return groupedProductDto.FirstOrDefault(gp => gp.CategoryId == groupedProductDto.Key).CategoryName;
        }
    }
}
