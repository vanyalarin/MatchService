namespace MatchService.EF.Migrations
{
    using MatchService.Data.Entity.StadiumAggregate;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MatchService.EF.MatchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MatchService.EF.MatchContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Func<List<Place>> placeGenerator = () =>
            {
                var retIt = new List<Place>();
                Random random = new Random();


                for (int i = 0; i < 100; i++)
                {
                    decimal randomNumber = random.Next(80, 120);
                    var newPlace = new Place() { Number = i, PriceMultiplier = randomNumber / 100 };
                    retIt.Add(newPlace);
                }
                return retIt;
            };

            context.Stadiums.AddOrUpdate(
              t => t.Id,
              new Stadium
              {
                  Name = "NSC Olimpiyskiy",
                  Location = "Kiev",
                  Sectors= new List<Sector>() {
                      new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 100m,
                          Number = 1,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 100m,
                          Number = 2,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 120m,
                          Number = 3,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 130m,
                          Number = 4,
                      },
                      new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 130m,
                          Number = 5,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 120m,
                          Number = 6,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 100m,
                          Number = 7,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 100m,
                          Number = 8,
                      }
                  }
              },
              new Stadium
              {
                  Name = "Arena Lviv",
                  Location = "Lviv",
                  Sectors = new List<Sector>() {
                      new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 100m,
                          Number = 1,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 100m,
                          Number = 2,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 120m,
                          Number = 3,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 130m,
                          Number = 4,
                      },
                      new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 130m,
                          Number = 5,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 120m,
                          Number = 6,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 100m,
                          Number = 7,
                      },new Sector() {
                          Places = placeGenerator(),
                          DefaultPrice = 100m,
                          Number = 8,
                      }
                  }
              }

            );
        }
    }
}
