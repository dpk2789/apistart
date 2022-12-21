using DbInfrastructure;
using DbInfrastructure.Repository;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _product;
        public ProductsController(IProductRepository product)
        {
            _product = product ??
                throw new ArgumentNullException(nameof(product));
        }
      
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> Get()
        {            
            return Ok(await _product.GetProducts());
        }

    
    }
}
