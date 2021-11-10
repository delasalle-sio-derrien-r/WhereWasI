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
    }
}
