using Kiosk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext(): base("DataContext")
        {

        }
        public DbSet<Item> Items { get; set; }
    }
}
