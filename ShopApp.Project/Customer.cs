using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Project
{
    class Customer
    {
        public string CostumerName { get; }
        public decimal Budget { get; set; }

        public Customer(string costumerName, decimal budget)
        {
            CostumerName = costumerName;
            Budget = budget;
        }


        public void Topup(string command)
        {
            String[] input = command.Split(" ");
            string topupAmount = input[1];
            decimal topupAmountInt = Decimal.Parse(topupAmount);
            Budget = Budget + topupAmountInt;
            Console.WriteLine("--> " + topupAmountInt + " Eur added. " + Budget + " Eur in a wallet.");
        }
    }
}

