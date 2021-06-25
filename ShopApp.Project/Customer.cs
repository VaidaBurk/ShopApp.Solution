using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Project
{
    class Customer
    {
        public string CustomerName { get; set; }
        public decimal Budget { get; set; }

        public Customer(string customerName, decimal budget)
        {
            CustomerName = customerName;
            Budget = budget;
        }

        public void Topup(decimal topupAmount)
        {
            Budget += topupAmount;
            Console.WriteLine($"--> {topupAmount} Eur added. {Budget} Eur in a wallet.");
        }
    }
}

