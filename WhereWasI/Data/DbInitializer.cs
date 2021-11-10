using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereWasI.Models;

namespace WhereWasI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if(context.Items.Any())
            {
                return;
            }

            var items = new Item[]
            {
                new Item{Name="Test1", LastNumber=1, InsertDate = DateTime.Now, Link="https://www.google.fr/"},
                new Item{Name="Test2", LastNumber=2, InsertDate = DateTime.Now, Link="https://www.google.fr/"},
                new Item{Name="Test3", LastNumber=3, InsertDate = DateTime.Now, Link="https://www.google.fr/"},
                new Item{Name="Test4", LastNumber=4, InsertDate = DateTime.Now, Link="https://www.google.fr/"},
            };

            var categories = new Category[]
            {
                new Category {Name="Cat1"},
                new Category {Name="Cat2"},
                new Category {Name="Cat3"},
                new Category {Name="Cat4"},
                new Category {Name="Cat5"},
            };

            var itemCategories = new ItemCategory[]
            {
                new ItemCategory {CategoryID=1, ItemID=1, Category=categories.Where(c => c.ID == 1).FirstOrDefault(), Item=items.Where(i => i.ID == 1).FirstOrDefault() },
                new ItemCategory {CategoryID=2, ItemID=2, Category=categories.Where(c => c.ID == 2).FirstOrDefault(), Item=items.Where(i => i.ID == 2).FirstOrDefault() },
                new ItemCategory {CategoryID=2, ItemID=3, Category=categories.Where(c => c.ID == 2).FirstOrDefault(), Item=items.Where(i => i.ID == 3).FirstOrDefault() },
                new ItemCategory {CategoryID=3, ItemID=4, Category=categories.Where(c => c.ID == 3).FirstOrDefault(), Item=items.Where(i => i.ID == 4).FirstOrDefault() },
                new ItemCategory {CategoryID=4, ItemID=4, Category=categories.Where(c => c.ID == 4).FirstOrDefault(), Item=items.Where(i => i.ID == 4).FirstOrDefault() },
            };

            foreach (Item item in items)
            {
                //var itemCategoriesTemp = itemCategories.Where(ic => ic.ItemID == item.ID);
                //item.ItemCategories = itemCategoriesTemp.ToList();
                context.Items.Add(item);
            }
            //context.SaveChanges();

            
            foreach (Category category in categories)
            {
                context.Categories.Add(category);
            }

            foreach (ItemCategory itemCategory in itemCategories)
            {
                context.ItemCategories.Add(itemCategory);
            }
            context.SaveChanges();
        }
    }
}
