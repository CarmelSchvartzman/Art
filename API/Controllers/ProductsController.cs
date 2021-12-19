using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _ctx;
        public ProductsController(StoreContext ctx)
        {
            _ctx = ctx;

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var res = await _ctx.Products.ToListAsync();

            return Ok(res);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>  GetProduct(int id)
        {
            Product p = await _ctx.Products.FindAsync(id);
            return Ok(p);
        }
    }
}