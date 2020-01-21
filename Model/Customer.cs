using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace restful_api.Models
{
    public class Customer
    {
        public int id{get;set;}
        public string name{get;set;}
        public string address{get;set;}
        [ForeignKeyAttribute("customer_id")]
        public ICollection<Login> Logins {get;set;}
        [ForeignKeyAttribute("customer_id")]
        public ICollection<Order> Orders {get;set;}
    }
}