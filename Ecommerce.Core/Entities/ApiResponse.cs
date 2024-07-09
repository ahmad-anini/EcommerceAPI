using System.Net;

namespace Ecommerce.Core.Entities
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = default!;
        public object Result { get; set; } = default!;
    }
}
