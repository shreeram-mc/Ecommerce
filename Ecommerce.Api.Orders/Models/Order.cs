using System;
using System.Collections.Generic;

namespace Ecommerce.Api.Orders.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public decimal Total { get; set; }

        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }       
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
