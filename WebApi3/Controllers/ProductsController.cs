using DbMysqlInfrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DbMysqlContext _dbContext;
        public ProductsController(DbMysqlContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Products.ToListAsync());
        }
    }
}
