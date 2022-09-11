using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDAL
    {
        private TestIAContext _context;
        public OrderDAL()
        {
            _context = new TestIAContext();
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders.Include("OrderDetails.Product").ToListAsync();
        }

        public async Task<Order?> GetOrder(int id)
        {
            Order? Order = await _context.Orders.Include("OrderDetails.Product").FirstOrDefaultAsync(e => e.Id == id);
            return Order;
        }
        public async Task<Order?> PutOrder(int id, Order Order)
        {

            _context.Update(Order);
            await _context.SaveChangesAsync();

            return await GetOrder(Order.Id);
        }

        public async Task<Order?> PostOrder(Order Order)
        {
            bool validateStock = await ValidateStock(Order.OrderDetails);
            if (!validateStock)
            {
                return null;
            }

            _context.Add(Order);
            await _context.SaveChangesAsync();

            return await GetOrder(Order.Id);
        }

        public async Task<int?> DeleteOrder(int id)
        {

            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
            {
                return null;
            }

            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();

            return id;
        }
        public bool OrderExists(int id)
        {

            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<bool> ValidateStock(List<OrderDetail> orderDetails)
        {
            Product? productToValidate = new Product();
            foreach (var item in orderDetails)
            {
                productToValidate = await _context.Products.FindAsync(item.ProductId);
                if (productToValidate == null || productToValidate.Stock < item.Quantity)
                {
                    return false;
                }
                else
                {
                    productToValidate.Stock = productToValidate.Stock - item.Quantity;
                    _context.Update(productToValidate);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
