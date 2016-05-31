namespace Kiosk.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kiosk.DataAccess.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Kiosk.DataAccess.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Items.AddOrUpdate(i => i.Name, new Item[] {
                new Item
                {
                    Name = "Toast",
                    Price = 200
                },
                new Item
                {
                    Name = "Egg Roll",
                    Price = 70
                },
                new Item
                {
                    Name = "Fish Pie",
                    Price = 100
                }
            });
        }
    }
}
