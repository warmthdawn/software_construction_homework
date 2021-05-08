using MySql.Data.EntityFramework;
using OrderManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagerFramework
{

    public class OrdingDBContext: DbContext
    {
        public OrdingDBContext()
            :base("name=default")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrdingDBContext>());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
