using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Server.Extensions;
using OnlineShop.Server.Models;
using OnlineShop.Server.Repos.ProductRepo;
using OnlineShop.Shared.DTOs;

namespace OnlineShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo ctx;
        private readonly IHostEnvironment env;

        public ProductsController(IProductRepo ctx, IHostEnvironment env)
        {
            this.ctx = ctx;
            this.env = env;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await ctx.GetItems();

                if (products == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDto = products.ConvertToDto();

                    return Ok(productDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        //[Route("GetProduct")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await ctx.GetItem(id);
                if (product == null)
                {
                    return BadRequest();
                }
                else
                {

                    var productDto = product.ConvertToDto();
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from Server");
            }
        }

        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var products = await ctx.GetItemsByCategory(categoryId);

                var productDtos = products.ConvertToDto();

                return Ok(productDtos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }
        }
        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] Product product)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    if (await ctx.ProductExists(id))
                    {
                        var newProd = await ctx.UpdateItem(id, product);
                        var productDto = newProd.ConvertToDto();
                        return StatusCode(204, productDto);

                    }
                    return BadRequest();
                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
                }
            }
            return BadRequest(ModelState);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    var newProd = await ctx.AddItem(product);
                    var productDto = newProd.ConvertToDto();

                    return CreatedAtAction(nameof(GetItem), new { id = productDto.Id }, productDto);

                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
                }
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                ctx.DeleteItem(id);
                return StatusCode(204, "Record Removed");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }


        }


    }
}
