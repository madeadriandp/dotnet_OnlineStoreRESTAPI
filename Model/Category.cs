using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace restful_api.Models
{
    public class Category
    {
        public int id{get;set;}
        public string name{get;set;}
        public string description{get;set;}
        [ForeignKey("cat_id")]
        public ICollection<Product> Products {get;set;}
    }
}