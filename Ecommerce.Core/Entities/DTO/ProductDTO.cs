namespace Ecommerce.Core.Entities.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public string? CategoryName { get; set; }

    }
}
