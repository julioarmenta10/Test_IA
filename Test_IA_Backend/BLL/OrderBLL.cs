using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class OrderBLL
    {
        private OrderDAL _DAL;

        public OrderBLL()
        {
            _DAL = new OrderDAL();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var data = await _DAL.GetAllOrders();
            return data;
        }

        public async Task<Order?> GetOrder(int id)
        {
            var data = await _DAL.GetOrder(id);
            return data;
        }

        public async Task<Order?> PutOrder(int id, Order Order)
        {
            var data = await _DAL.PutOrder(id, Order);
            return data;
        }

        public async Task<Order?> PostOrder(Order Order)
        {
            var data = await _DAL.PostOrder(Order);
            return data;
        }

        public async Task<int?> DeleteOrder(int id)
        {

            var data = await _DAL.DeleteOrder(id);
            return data;
        }

        public bool OrderExists(int id)
        {
            var data = _DAL.OrderExists(id);
            return data;
        }

    }
}