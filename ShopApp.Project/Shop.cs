using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Project
{
    class Shop
    {
        Customer Customer;
        List<Item> Items = new List<Item>();

        public Shop()
        {
            Items.Add(new Item("Candy", 4));
            Items.Add(new Item("Book", 8));
            Items.Add(new Item("Juice", 2));
            Customer = new("Matt", 10);
        }

        public void SearchForItemInShop(string command)
        {
            String[] input = command.Split(" ");
            string requestedItem = input[1];
            List<Item> foundItems = Items.Where(item => item.ItemName == requestedItem).ToList();

            if (foundItems.Count != 0)
            {
                PurchaseItem(input, foundItems);
            }
            else
            {
                Console.WriteLine("--> '" + requestedItem +"' is not on stock");
            }
        }

        
        public void PurchaseItem(String[] input, List<Item> foundItems)
        {
            Item foundItem = foundItems.First();
            decimal RequestedItemsPrice = CountRequestItemsPrice(input, foundItem);
            if (Customer.Budget >= RequestedItemsPrice)
            {
                Customer.Budget = Customer.Budget - RequestedItemsPrice;
                Console.WriteLine("--> " + foundItem.ItemName + " bought! " + Customer.Budget + " Eur left.");
            }
            else
            {
                Console.WriteLine("--> Not enough money :(");
            }
        }

        public decimal CountRequestItemsPrice(string[] input, Item foundItem)
        {   
            if (input.Length == 3)
            {
                int RequestedQuantity = Int32.Parse(input[2]);
                decimal RequestedItemsPrice = foundItem.Price * RequestedQuantity;
                return RequestedItemsPrice;
            }
            else
            {
                decimal RequestedItemsPrice = foundItem.Price;
                return RequestedItemsPrice;
            }
        }

        public void TopupCustomer(string Command)
        {
            Customer.Topup(Command);
        }
    }
}