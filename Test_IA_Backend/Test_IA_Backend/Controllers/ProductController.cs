using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repository;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test_IA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductBLL _BLL;
        public ProductController()
        {
            _BLL = new ProductBLL();
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _BLL.GetAllProducts();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product? product = await _BLL.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                var result = await _BLL.PutProduct(id, product);
                return Ok(result);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_BLL.ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return Ok(result);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product?>> PostProduct(Product product)
        {
            var result = await _BLL.PostProduct(product);
            if (result == null)
            {
                return BadRequest($"Ya existe un producto con el SKU {product.SKU}");
            }
            return result;
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _BLL.DeleteProduct(id);

            if (result == null)
            {
                return NotFound("El registro a eliminar no existe");
            }

            return Ok("El registro ha sido eliminado");
        }

       
        
    }
}
