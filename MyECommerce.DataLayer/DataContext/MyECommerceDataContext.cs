using MyECommerce.Entities.Concrete;
using System.Data.Entity;

namespace MyECommerce.DataLayer.DataContext
{
    public class MyECommerceDataContext : DbContext
    {
        public MyECommerceDataContext()
            : base(System.Configuration.ConfigurationManager.ConnectionStrings["MyECommerceDatabaseConnection"].ConnectionString)
        {

        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Basket> Basket { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Orders> Orders { get; set; }


    }
}


