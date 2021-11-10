using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereWasI.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LastNumber { get; set; }
        public DateTime InsertDate { get; set; }
        public string Link { get; set; }
        public ICollection<ItemCategory> ItemCategories { get; set; }
    }
}
