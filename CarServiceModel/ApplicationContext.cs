using System.Data.Entity;

namespace CarServiceModel
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ApplicationContext: DbContext
    {

        public ApplicationContext(): base("Server=localhost;port=3306;Database=carservice;Uid=root;Pwd=******;")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
