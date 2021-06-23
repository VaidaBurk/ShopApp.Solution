using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Item> Items = new List<Item>();

            //Items.Add(new Item("Candy", 4));
            //Items.Add(new Item("Book", 8));
            //Items.Add(new Item("Juice", 2));
            
            //Customer Customer = new Customer("Matt", 10);
            Shop Shop = new Shop();

            Console.WriteLine("Welcome! What would you like to buy?");
            string Command = "";

            while(Command != "Exit")
            {
                Command = Console.ReadLine();
                if (Command.StartsWith("Buy"))
                {
                    Shop.SearchForItemInShop(Command);
                }

                if (Command.StartsWith("Topup"))
                {
                    //Customer.Topup(Command);
                    Shop.TopupCustomer(Command);
                }
            }
        }
    }
}
