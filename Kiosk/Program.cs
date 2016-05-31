using Kiosk.DataAccess;
using Kiosk.Domain;
using Kiosk.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk
{
    class Program
    {
        public static KioskManager _kiosk;

        static void Main(string[] args)
        {
            //Create our Kiosk Object
            _kiosk = new KioskManager(new DataContext());

            bool quit = false;
            do
            {
                //Display Menu
                DisplayMenu();

                //Ask for user for Command
                var cmd = int.Parse(Console.ReadLine());
                switch (cmd)
                {
                    case 0: quit = true; break;
                    case 1: DisplayItems(); break;
                    case 2: AddItem(); break;
                }
            } while (quit == false);
        }

        #region Display Item Command
        private static void DisplayItems()
        {
            //Get Items from Object
            var items = _kiosk.GetItems();

            //Display Items
            Console.WriteLine();
            Dashes("Display Items");
            if (items.Count() > 0)
            {
                var query = from item in items
                            orderby item.Name
                            select item;

                //Iterate over the Items displaying each of them
                foreach (var item in query)
                {
                    Console.WriteLine(" - " + item.Name);
                }
            }
            else
            {
                //If there are no Items
                Console.WriteLine("There are no items in the Kiosk");
            }

            Dash();
            Console.Write("Press any Key to Continue ");
            Console.ReadKey();
        }
        #endregion

        #region Add Item Command
        private static void AddItem()
        {
            Dashes("Add Item");
            Console.Write("Enter Item Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Item Price: ");
            var price = decimal.Parse(Console.ReadLine());

            var item = new Item();
            item.Name = name;
            item.Price = price;

            _kiosk.AddItem(item);
            Console.WriteLine("Item Added Successfully");
        }
        #endregion

        #region Utils

        private static void DisplayMenu()
        {
            Dashes("Here are your Options: ");
            Console.WriteLine("\n1. Display Items");
            Console.WriteLine("\n2. Add Item");
            Console.WriteLine("\nEnter 0 to Quit\n");
        }

        public static void Dashes(string message)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine(message);
            Console.WriteLine("=========================================");
        }
        public static void Dash()
        {
            Console.WriteLine("-----------------------------------------\n\n");
        }
        #endregion
    }
}
