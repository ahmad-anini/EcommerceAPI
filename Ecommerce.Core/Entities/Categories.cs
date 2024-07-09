namespace Ecommerce.Core.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<Products> Products { get; set; } = new List<Products>();



    }
}
