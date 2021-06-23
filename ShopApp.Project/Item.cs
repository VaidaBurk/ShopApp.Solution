using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Project
{
    class Item
    {
        public string ItemName { get; }
        public decimal Price { get; }
        
        public Item(string itemName, decimal price)
        {
            ItemName = itemName;
            Price = price;
        }
    }
}
