using Kiosk.DataAccess;
using Kiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Domain
{
    public class KioskManager
    {
        private DataContext _dataContext;

        public KioskManager(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Item> GetItems()
        {
            return _dataContext.Items;
        }

        public Item AddItem(Item item)
        {
            var dbItem = _dataContext.Items.Where(i => i.Name == item.Name).FirstOrDefault();

            if (dbItem != null) throw new Exception($"Item {dbItem.Name} already exists");

            _dataContext.Items.Add(item);
            _dataContext.SaveChanges();
            return item;
        }
    }
}
