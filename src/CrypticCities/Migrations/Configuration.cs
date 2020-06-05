namespace CrypticCities.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrypticCities.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrypticCities.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.CrypticCities.AddOrUpdate(
              p => p.Clue,
              new CrypticCity { Clue = "To set a striped insect on fire", Hint = "Vancouver's neighbour", Answer = "Burnaby" },
              new CrypticCity { Clue = "cold, to hit with a stick", Hint = "Known for it's corn", Answer = "Chilliwack" },
              new CrypticCity { Clue = "to make sound by blowing from the lips, she", Hint = "Olypics 2010", Answer = "Whistler" }
            );
            context.SaveChanges();
        }
    }
}
