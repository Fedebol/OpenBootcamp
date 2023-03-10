using DotNetApiRestfulEjer9.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DotNetApiRestfulEjer9.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private const string ApiTestURL = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetProductsData")]
        public async Task<IActionResult> GetProductsDataAsync()
        {
            var response = await _httpClient.GetStreamAsync(ApiTestURL);

            var productsData = await JsonSerializer.DeserializeAsync<List<Producto2>>(response);

            return Ok(productsData);
        }
    }
}
