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
    public class OrderController : ControllerBase
    {
        private OrderBLL _BLL;
        public OrderController()
        {
            _BLL = new OrderBLL();
        }

        // GET: api/Order
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _BLL.GetAllOrders();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            Order? Order = await _BLL.GetOrder(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order Order)
        {
            if (id != Order.Id)
            {
                return BadRequest();
            }

            try
            {
                var result = await _BLL.PutOrder(id, Order);
                return Ok(result);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_BLL.OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<Order?>> PostOrder(Order Order)
        {
            var result=await _BLL.PostOrder(Order);
            if (result == null)
            {
                return BadRequest("Un producto dentro de la orden no cuenta con stock o no existe.");

            }
            return result;
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _BLL.DeleteOrder(id);

            if (result == null)
            {
                return NotFound("El registro a eliminar no existe");
            }

            return Ok("El registro ha sido eliminado");

        }



    }
}
