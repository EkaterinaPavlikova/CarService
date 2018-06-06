using CarService.Data.Models;
using System.Data.Entity;

namespace CarService.Data.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ApplicationContext: DbContext
    {

        public ApplicationContext(): base("Server=localhost;port=3306;Database=carservice;Uid=root;Pwd=******;")
        {

        }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

    }
}
