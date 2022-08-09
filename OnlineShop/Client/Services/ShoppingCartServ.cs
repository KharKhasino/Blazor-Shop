using Newtonsoft.Json;
using OnlineShop.Shared.DTOs;
using System.Net.Http.Json;
using System.Text;

namespace OnlineShop.Client.Services
{

        public class ShoppingCartServ : IShoppingServ
        {
            private readonly HttpClient http;
            public ShoppingCartServ(HttpClient http)
            {
                this.http = http;
            }
            public async Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAdd)
            {
                try
                {
                    var response = await http.PostAsJsonAsync<CartItemToAddDto>("api/ShoppingCart", cartItemToAdd);

                    if (response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            return default(CartItemDto);
                        }

                        return await response.Content.ReadFromJsonAsync<CartItemDto>();

                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            public async Task<CartItemDto> DeleteItem(int id)
            {
                try
                {
                    var response = await http.DeleteAsync($"api/ShoppingCart/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<CartItemDto>();
                    }
                    return default(CartItemDto);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public async Task<List<CartItemDto>> GetItems(int userId)
            {
                try
                {
                    var response = await http.GetAsync($"api/ShoppingCart/{userId}/GetItems");

                    if (response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            return Enumerable.Empty<CartItemDto>().ToList();
                        }
                        return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            public async Task<CartItemDto> UpdateItem(CartItemQtyUpdateDto cartItemQtyUpdate)
            {
                try
                {
                    var jsonReq = JsonConvert.SerializeObject(cartItemQtyUpdate);
                    var content = new StringContent(jsonReq, Encoding.UTF8, "application/json-patch+json");

                    var response = await http.PutAsync($"api/ShoppingCart/{cartItemQtyUpdate.CartId}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<CartItemDto>();
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    
}
