using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WhereWasI.Data;
using WhereWasI.Controllers;
using Xunit;
using WhereWasI.Models;
using Microsoft.AspNetCore.Mvc;

namespace WhereWasI.Tests
{
    public class MySQLCategoriesControllerTest : CategoriesControllerTest
    {
        public MySQLCategoriesControllerTest()
        : base(
            new DbContextOptionsBuilder<ApplicationContext>()
                .UseMySql("server=localhost;user=wherewasi_admin;password=admin;database=wherewasi", new MySqlServerVersion(new Version(5, 7, 31)))
                .Options)
        {
        }

        [Fact]
        public async void Can_get_categories()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new CategoriesController(context);

                var categories = await controller.GetCategories();

                Assert.Equal(5, categories.Count);
                Assert.Equal("Test1", categories[0].Name);
                Assert.Equal("Test2", categories[1].Name);
                Assert.Equal("Test3", categories[2].Name);
                Assert.Equal("Test4", categories[3].Name);
                Assert.Equal("Test5", categories[4].Name);
            }
        }

        [Fact]
        public async void Can_get_category()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new CategoriesController(context);

                var category = await controller.GetCategory(1);
                Assert.Equal("Test1", category.Value.Name);

                category = await controller.GetCategory(5);
                Assert.Equal("Test5", category.Value.Name);

            }
        }

        [Fact]
        public async void Can_add_category()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new CategoriesController(context);

                var actionResult = await controller.PostCategory(new Category { Name = "Test6" });
                var createdAtActionResult = (CreatedAtActionResult)actionResult.Result;
                var category = (Category)createdAtActionResult.Value;

                Assert.Equal("Test6", category.Name);
            }

            using (var context = new ApplicationContext(ContextOptions))
            {
                var category = await context.Set<Category>().SingleAsync(i => i.Name == "Test6");

                Assert.Equal("Test6", category.Name);
            }
        }

        [Fact]
        public async void Can_put_item()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new CategoriesController(context);

                var category = await controller.GetCategory(3);
                Assert.Equal("Test3", category.Value.Name);

                category.Value.Name = "NameModified";

                var actionResult = await controller.PutCategory(3, category.Value);

                var categoryReturned = await controller.GetCategory(3);
                Assert.Equal("NameModified", categoryReturned.Value.Name);

            }
        }
    }
}
