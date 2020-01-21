using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace restful_api.Models
{
    public class Order
    {
        public int id{get;set;}
        public int customer_id{get;set;}
        public int delivery_id{get;set;}
        [ForeignKeyAttribute("order_id")]
        public ICollection<OrderItem> OrderItems {get;set;}
    }
}