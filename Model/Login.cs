using System.ComponentModel.DataAnnotations.Schema;
namespace restful_api.Models
{
    public class Login
    {
        public int id{get;set;}
        public int customer_id{get;set;}
        public string username{get;set;}
        public string password{get;set;}
    }
}