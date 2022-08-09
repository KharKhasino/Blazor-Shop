using Microsoft.AspNetCore.Components;
using OnlineShop.Shared.DTOs;

namespace OnlineShop.Client.Pages
{
    public partial class DisplayProducts
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
