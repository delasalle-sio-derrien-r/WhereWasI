using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WhereWasI.Data;
using WhereWasI.Controllers;
using Xunit;

namespace WhereWasI.Tests.CategoriesController.Tests
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
            }
        }
    }
}
