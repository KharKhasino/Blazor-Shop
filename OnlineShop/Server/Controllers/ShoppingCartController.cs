using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Server.Extensions;
using OnlineShop.Server.Models;
using OnlineShop.Server.Repos.ProductRepo;
using OnlineShop.Server.Repos.ShoppingCartRepo;
using OnlineShop.Shared.DTOs;

namespace OnlineShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingRepo cartCX;
        private readonly IProductRepo cartPX;


        public ShoppingCartController(IShoppingRepo shop, IProductRepo pro)
        {
            cartCX = shop;
            cartPX = pro;
        }

        // GET: api/ShoppingCart
        [HttpGet]
        [Route("{userId}/GetItems")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                var cartItems = await cartCX.GetItems(userId);

                if (cartItems == null)
                {
                    return NoContent();
                }

                var products = await cartPX.GetItems();

                if (products == null)
                {
                    throw new Exception("No Products Exist!");
                }

                var cartItemsDto = cartItems.ConvertToDto(products);

                return Ok(cartItemsDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong!");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cart>> GetItem(int id)
        {
            try
            {
                var cartItem = await cartCX.GetItem(id);
                if (cartItem == null)
                {
                    return NotFound();
                }
                var product = await cartPX.GetItem(cartItem.ProductId);
                if (product == null)
                {
                    return BadRequest();
                }
                var cartItemDto = cartItem.ConvertToDto(product);
                return Ok(cartItemDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong!");

            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCart(int id, CartItemQtyUpdateDto cartItemQtyUpdate)
        {
            try
            {
                var cartItem = await cartCX.UpdateQty(id, cartItemQtyUpdate);
                if (cartItem == null)
                {
                    return NotFound();
                }

                var product = await cartPX.GetItem(cartItem.ProductId);

                var cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Cart>> PostItem(CartItemToAddDto cartItemToAdd)
        {
            try
            {
                var newCartItem = await cartCX.AddItem(cartItemToAdd);

                if (newCartItem == null)
                {
                    return NoContent();
                }

                var product = await cartPX.GetItem(newCartItem.ProductId);

                if (product == null)
                {
                    throw new Exception($"Something went wrong when attempting to retrieve product (productId:({cartItemToAdd.ProductId})");
                }

                var newCartItemDto = newCartItem.ConvertToDto(product);

                return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong!");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
        {
            try
            {
                var cartItem = await cartCX.DeleteItem(id);

                if (cartItem == null)
                {
                    return NotFound();
                }

                var product = await cartPX.GetItem(cartItem.ProductId);

                if (product == null)
                    return NotFound();

                var cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went Wrong!");
            }
        }
    }
}
