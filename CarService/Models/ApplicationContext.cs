

using System.Data.Entity;

namespace CarService.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ApplicationContext: DbContext
    {

        public ApplicationContext(): base("DefaultConnection")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
