using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Project
{
    class Shop
    {
        //Customer Customer;
        List<Item> Items = new List<Item>();
        List<Customer> Customers = new List<Customer>();

        public Shop()
        {
            Items.Add(new Item("Candy", 4));
            Items.Add(new Item("Book", 8));
            Items.Add(new Item("Juice", 2));
        }

        public void CreateCustomer (string command)
        {
            String[] input = command.Split(" ");
            string customerName = command.Split(" ")[2];
            decimal budget = Decimal.Parse(input[3]);
            Customers.Add(new Customer(customerName, budget));
            Console.WriteLine($"Customer {customerName} created. {budget} Eur in customer's wallet.");
        }

        public void SearchAndPurchase(string command)
        {
            String[] input = command.Split(" ");
            string customerName = input[0];
            string requestedItem = input[2];
            List<Item> foundItems = Items.Where(item => item.ItemName == requestedItem).ToList();
            Item foundItem = foundItems.First();
            Customer currentCustomer = Customers.Where(customer => customer.CustomerName == customerName).First();

            if (foundItems.Count != 0)
            {
                PurchaseItem(input, foundItem, currentCustomer);
            }
            else
            {
                Console.WriteLine($"--> '{requestedItem}' is not on stock");
            }
        }
        
        public void PurchaseItem(String[] input, Item foundItem, Customer currentCustomer)
        {
            decimal requestedItemsPrice = RequestedItemsPrice(input, foundItem);
            if (currentCustomer.Budget >= requestedItemsPrice)
            {
                //currentCustomer.Budget = currentCustomer.Budget - requestedItemsPrice;
                currentCustomer.Budget -= requestedItemsPrice;
                Console.WriteLine($"--> {currentCustomer.CustomerName} bought {foundItem.ItemName}. {currentCustomer.Budget} Eur left.");
            }
            else
            {
                Console.WriteLine("--> Not enough money :(");
            }
        }

        public decimal RequestedItemsPrice(string[] input, Item foundItem)
        {   
            if (input.Length == 4)
            {
                decimal requestedQuantity = Decimal.Parse(input[3]);
                decimal requestedItemsPrice = foundItem.Price * requestedQuantity;
                return requestedItemsPrice;
            }
            else
            {
                decimal requestedItemsPrice = foundItem.Price;
                return requestedItemsPrice;
            }
        }

        public void TopupCustomer(string command)
        {
            String[] input = command.Split(" ");
            string customerName = input[1];
            decimal topupAmount = Decimal.Parse(input[2]);
            Customer currentCustomer = Customers.Where(customer => customer.CustomerName == customerName).First();
            currentCustomer.Topup(topupAmount);
        }
    }
}