using Microsoft.EntityFrameworkCore;
using System;
using WhereWasI.Controllers;
using WhereWasI.Data;
using WhereWasI.Models;

namespace WhereWasI.Tests
{
    public class ItemsControllerTest
    {
        protected DbContextOptions<ApplicationContext> ContextOptions { get; }

        protected ItemsControllerTest(DbContextOptions<ApplicationContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();
        }

        private void Seed()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var items = new Item[]
                {
                    new Item{Name="Test1", LastNumber=1, InsertDate = DateTime.Now, Link="https://www.google.fr/"},
                    new Item{Name="Test2", LastNumber=2, InsertDate = DateTime.Now, Link="https://www.google.fr/"},
                    new Item{Name="Test3", LastNumber=3, InsertDate = DateTime.Now, Link="https://www.google.fr/"},
                    new Item{Name="Test4", LastNumber=4, InsertDate = DateTime.Now, Link="https://www.google.fr/"},
                };  

                foreach(Item item in items)
                {
                    context.Add(item);
                }

                var categories = new Category[]
                {
                    new Category{Name="Test1"},
                    new Category{Name="Test2"},
                    new Category{Name="Test3"},
                    new Category{Name="Test4"},
                    new Category{Name="Test5"},
                };

                foreach (Category category in categories)
                {
                    context.Add(category);
                }

                context.SaveChanges();
            }
        }
    }
}
