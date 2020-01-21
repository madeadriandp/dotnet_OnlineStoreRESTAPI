
using restful_api.Models;
using Microsoft.EntityFrameworkCore;

namespace restful_api.Database
{
    public class CoreDbContext: DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options):base(options){}

        public DbSet<Login> Logins {get;set;}
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Order> Orders{get;set;}
        public DbSet<OrderItem> OrderItems {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<DeliveryAddress> DeliveryAddresses {get;set;}

    }
}