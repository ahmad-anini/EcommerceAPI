namespace Ecommerce.Core.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public int LocalUserId { get; set; }
        public string OrderStatus { get; set; } = default!;
        public DateTime OrderDate { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        public LocalUser? LocalUser { get; set; }



    }
}
