namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; } 
        public string OrderStatus { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
