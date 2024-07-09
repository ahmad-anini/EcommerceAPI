namespace Ecommerce.Core.Entities
{
    public class LocalUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? Phone { get; set; } = default!;
        public string Role { get; set; } = default!;
        public List<Orders> Orders { get; set; } = new List<Orders>();

    }
}
