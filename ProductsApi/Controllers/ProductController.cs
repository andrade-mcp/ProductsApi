using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Model;

namespace ProductsApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productService;
        private readonly ILogger<ProductController> _logger;
        
        public ProductController(IProductsService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieve a list of all products in JSON format
        /// </summary>
        [HttpGet("/api/products")]
        public async Task<ActionResult<IEnumerable<Product>>> Products()
        {

            var headerValue = Request.Headers["Api_key"];

            try
            {
                return Ok(await _productService.GetAllProductsAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Retrieve get all products of a specific colour
        /// </summary>
        [HttpGet("/api/products/{color}")]
        public async Task<ActionResult<IEnumerable<Product>>> Products(string color)
        {
            try
            {
                return Ok(await _productService.GetProductByColorAsync(color));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}
