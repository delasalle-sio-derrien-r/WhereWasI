using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using WhereWasI.Controllers;
using WhereWasI.Data;
using Xunit;
using WhereWasI.Models;
using Microsoft.AspNetCore.Mvc;

namespace WhereWasI.Tests
{
    public class MySQLItemsControllerTest : ItemsControllerTest
    {
        public MySQLItemsControllerTest()
        : base(
            new DbContextOptionsBuilder<ApplicationContext>()
                .UseMySql("server=localhost;user=wherewasi_admin;password=admin;database=wherewasi", new MySqlServerVersion(new Version(5, 7, 31)))
                .Options)
        { 
        }

        #region ItemsTest
        [Fact]
        public async void Can_get_items()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new ItemsController(context);

                var items = await controller.GetItems();

                Assert.Equal(4, items.Count);
                Assert.Equal("Test1", items[0].Name);
                Assert.Equal("Test2", items[1].Name);
                Assert.Equal("Test3", items[2].Name);
                Assert.Equal("Test4", items[3].Name);
            }
        }

        [Fact]
        public async void Can_get_item()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new ItemsController(context);

                var actionResult = await controller.GetItem(1);
                var item = actionResult.Value;

                Assert.Equal("Test1", item.Name);
            }
        }

        [Fact]
        public async void Can_add_item()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new ItemsController(context);

                var actionResult = await controller.PostItem(new Item { Name = "Test5", LastNumber = 1, InsertDate = DateTime.Now, Link = "https://www.google.fr/" });
                var createdAtActionResult = (CreatedAtActionResult)actionResult.Result;
                var item = (Item)createdAtActionResult.Value;

                Assert.Equal("Test5", item.Name);
            }

            using (var context = new ApplicationContext(ContextOptions))
            {
                var item = await context.Set<Item>().SingleAsync(i => i.Name == "Test5");

                Assert.Equal("Test5", item.Name);
            }
        }

        [Fact]
        public async void Can_delete_item()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new ItemsController(context);
                
                var actionResult = await controller.GetItem(1);
                var item = actionResult.Value;

                Assert.Equal("Test1", item.Name);

                actionResult = await controller.DeleteItem(item.ID);
                actionResult = await controller.GetItem(1);

                Assert.Null(actionResult.Value);

            }
        }
        
        [Fact]
        public async void Can_put_item()
        {
            using (var context = new ApplicationContext(ContextOptions))
            {
                var controller = new ItemsController(context);

                var item = await controller.GetItem(3);
                Assert.Equal("Test3", item.Value.Name);

                item.Value.Name = "NameModified";

                var actionResult = await controller.PutItem(3, item.Value);

                var itemReturned = await controller.GetItem(3);
                Assert.Equal("NameModified", itemReturned.Value.Name);

            }
        }
        #endregion
        #region CategoriesTest
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
        public async void Can_put_category()
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
        #endregion
    }
}
