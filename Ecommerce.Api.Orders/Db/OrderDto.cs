using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Api.Orders.Db
{
    public class OrderDto
    {
        public int Id { get; set; }
        
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; } 

        public decimal Total { get; set; }

        [ForeignKey("OrderId")]        
        public virtual List<ItemDto> ItemDtos { get; set; }
    }


    public class ItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }

}
