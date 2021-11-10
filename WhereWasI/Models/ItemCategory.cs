using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereWasI.Models
{
    public class ItemCategory
    {
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
