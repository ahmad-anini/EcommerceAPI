namespace Ecommerce.Core.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Products? Products { get; set; }
        public Orders? Orders { get; set; }



    }
}
