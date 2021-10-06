using Mods;
using Bus;
using System.Collections.Generic;
using System;


namespace UI
{
    public class BeerMenu : IMenu
    {
        private IBL _bl;

        public BeerMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start(){}

        public void Start(Store store)
        {
            List<Beer> beers = _bl.GetAllBeers(store);
            Console.WriteLine("Choose a Beer:\n");
            
            for(int i = 0; i < beers.Count; i++)
            {
                Console.WriteLine("[" + i + "] " + beers[i].Name);
            }
            Console.WriteLine("[x] (Exit store)");
            Gettinginput:
            string choice = Console.ReadLine();

            int input;
            if (int.TryParse(choice, out input))
            {
                Console.WriteLine("input: " + input);
            }
            else if (choice == "x" || choice == "X")
            {
                return;
            }
            else
            {
                Console.WriteLine("invalid input, not a number");
                goto Gettinginput;
            }

            if(input >= 0 && input < beers.Count)
            {
                Console.WriteLine(beers[input]);
                
            }
            else
            {
               Console.WriteLine("invalid input, out of range");
                goto Gettinginput;  
            }

            GettingQ:
            Console.WriteLine("How many?");
            string sQ = Console.ReadLine();

            int Q;
            if(!int.TryParse(sQ, out Q))
            {
                Console.WriteLine("Please answer with a number");
                goto GettingQ;
            }

            if(Q < 0)
            {
                Console.WriteLine("Please enter a positive number");
                Console.WriteLine("  Nice Try");
                goto GettingQ;
            }

            if(Q > beers[input].Stock)
            {
                System.Console.WriteLine("Cannot order more than available");
                goto GettingQ;
            }

            Order order = new Order()
            {
                SelectedBeer = beers[input],
                Quantity = Q
            };

            orderid:
            Console.WriteLine($"Order selected. Total is ${order.GetTotal()}\n\nPlease confirm your customer ID");
            string sid = Console.ReadLine();

            int cusid;
            if(!int.TryParse(sid, out cusid))
            {
                Console.WriteLine("ID consists of numbers");
                goto orderid;
            }

            if(_bl.IsCustomerIdUnique(cusid))
            {
                Console.WriteLine("ID not found");
                goto orderid;
            }

            _bl.AddOrder(order, cusid);
            
            // bool endswitch = true;
            // do
            // {
            //     string choice = Console.ReadLine();
            //     switch(choice)
            //     {

            //     }
            // }
        }
    }
}