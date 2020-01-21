using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace restful_api.Models
{
    public class DeliveryAddress
    {
        public int id{get;set;}
        public string name{get;set;}
        public string address{get;set;}
        [ForeignKeyAttribute("delivery_id")]
        public ICollection<Order> Orders {get;set;}
    }
}