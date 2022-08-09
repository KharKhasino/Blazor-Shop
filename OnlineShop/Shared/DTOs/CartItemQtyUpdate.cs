using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Shared.DTOs
{
    public class CartItemQtyUpdateDto
    {
        public int CartId { get; set; }
        public int Qty { get; set; }
    }
}
