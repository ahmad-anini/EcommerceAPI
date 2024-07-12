namespace Ecommerce.Core.Entities.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; } = default!;
        public DateTime OrderDate { get; set; }
    }
}
