namespace Ecommerce.Core.Entities.DTO
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = default!;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }

    }
}
