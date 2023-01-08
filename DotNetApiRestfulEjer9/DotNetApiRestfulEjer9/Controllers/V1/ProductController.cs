using DotNetApiRestfulEjer9.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DotNetApiRestfulEjer9.Controllers.V1
{
    [ApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetProductsData")]
        public async Task <IActionResult> GetProductsDataAsync()
        {
            var response = await _httpClient.GetStreamAsync(ApiTestURL);

            var productsData = await JsonSerializer.DeserializeAsync<Producto1>(response);

            return Ok(productsData);
        }
    }
}
