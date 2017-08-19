using System.Data.Entity;

namespace MyECommerce.DataLayer.DataContext
{
    public class MyECommerceDataContext : DbContext
    {
        public MyECommerceDataContext()
            : base(System.Configuration.ConfigurationManager.ConnectionStrings["MyECommerceDatabaseConnection"].ConnectionString)
        {

        }

        //public DbSet<User> Users { get; set; }
        

    }
}


