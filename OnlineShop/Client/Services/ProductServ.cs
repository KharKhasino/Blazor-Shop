using OnlineShop.Shared.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace OnlineShop.Client.Services
{
    public class ProductServ : IProductServ
    {
        private readonly HttpClient http;
        public ProductServ(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                var resp = await http.GetAsync("api/Product");
                if (resp.IsSuccessStatusCode)
                {
                    if (resp.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductDto>();
                    }
                    return await resp.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
                }
                else
                {
                    var Msg = await resp.Content.ReadAsStringAsync();
                    throw new Exception(Msg);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductDto> GetItem(int id)
        {
            try
            {
                var resp = await http.GetAsync($"api/product/{id}");
                if (resp.IsSuccessStatusCode)
                {
                    if (resp.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(ProductDto);
                    }
                    return await resp.Content.ReadFromJsonAsync<ProductDto>();
                }
                else
                {
                    var Msg = await resp.Content.ReadAsStringAsync();
                    throw new Exception(Msg);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ProductDto> UpdateItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> SaveItem(ProductDto product)
        {
            try
            {
                var resp = await http.PostAsJsonAsync($"api/product", product);
                if (resp.IsSuccessStatusCode)
                {
                    if (resp.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(ProductDto);
                    }
                    return await resp.Content.ReadFromJsonAsync<ProductDto>();
                }
                else
                {
                    var Msg = await resp.Content.ReadAsStringAsync();
                    throw new Exception(Msg);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ProductDto> UpdateItem(int id, ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}

