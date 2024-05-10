using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product_Request : Request
    {
        public Guid? ProductId { get; set; }
    }
    public class Products_Response: Response
    {
        public IEnumerable<Product_Response> Products { get; set; }
    }
    public class Product_Response: Response
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int Stock { get; set; }
    }

}
