namespace Domain.Models
{
    public class Cart_Request: Request
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }
    }

    public class Cart_Response : Response
    {
        public IEnumerable<Product_Response> Products { get; set; }
    }
}

