using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace restful_api.Models
{
    public class Product
    {
        public int id{get;set;}
        public int cat_id{get;set;}
        public string name{get;set;}
        public int price{get;set;}
        [ForeignKeyAttribute("product_id")]
        public ICollection<OrderItem> OrderItems {get;set;}
        
    }
}