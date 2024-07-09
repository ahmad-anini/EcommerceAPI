namespace Ecommerce.Core.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public Categories? Category { get; set; }
        public List<OrderDetails>? OrderDetails { get; set; } = new List<OrderDetails>();



    }
}
