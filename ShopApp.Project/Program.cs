using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            Console.WriteLine("Commands:");
            Console.WriteLine("Create customer 'name' 'budget'");
            Console.WriteLine("'name' Buys 'item' 'quantity (optional, default = 1)'");
            Console.WriteLine("Topup 'name' 'amount'");
            Console.WriteLine("Exit");
            string command = "";

            while(command != "Exit")
            {
                command = Console.ReadLine();
                if (command.Contains("Buys"))
                {
                    shop.SearchAndPurchase(command);
                }

                if (command.StartsWith("Topup"))
                {
                    shop.TopupCustomer(command);
                }

                if (command.StartsWith("Create customer"))
                {
                    shop.CreateCustomer(command);
                }
            }
        }
    }
}
