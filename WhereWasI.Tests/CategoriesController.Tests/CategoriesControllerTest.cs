using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WhereWasI.Data;
using WhereWasI.Models;

namespace WhereWasI.Tests.CategoriesController.Tests
{
    public class CategoriesControllerTest
    {
        protected DbContextOptions<ApplicationContext> ContextOptions { get; }

        protected CategoriesControllerTest(DbContextOptions<ApplicationContext> contextOptions)
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

                var categories = new Category[]
                {
                    new Category{Name="Test1"},
                    new Category{Name="Test2"},
                    new Category{Name="Test3"},
                    new Category{Name="Test4"},
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
