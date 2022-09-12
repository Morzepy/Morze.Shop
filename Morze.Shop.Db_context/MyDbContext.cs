using System.Data.Entity;


namespace Morze.Shop.Db_context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base(@"Data Source=DESKTOP-TESC0CJ\SQLEXPRESS;Initial Catalog=Shop_Database;Integrated Security=True")
        {}

        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }


    }
}
