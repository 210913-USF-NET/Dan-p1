using System;
using System.Collections.Generic;
using Bus;
using Mods;

namespace UI
{
    public class MainMenu : IMenu
    {
        private IBL _bl;

        public MainMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start(Store store){}
       public void Start() 
       {
            
        
            Console.WriteLine("\nHopCity\n");
           // Customer customer = new Customer("Dan", 23);

            saystores:
            Console.WriteLine("Select a store location");
            List<Store> stores = _bl.GetAllStores();
            for(int i = 0; i < stores.Count; i++)
            {
                Console.WriteLine("[" + i + "] " + stores[i]);
            } 
            Console.WriteLine("[x] LogOut\n");
            

            string input = Console.ReadLine();

            if (input == "x")
            {
                goto end;
            }

            int storeindex;
            if (!int.TryParse(input, out storeindex))
            {
                Console.WriteLine("select store using number or input x to logout\n");
                goto saystores;
            }

            if (storeindex < 0 || storeindex > stores.Count - 1)
            {
                Console.WriteLine($"please choose a number from 0 to {stores.Count - 1}");
                goto saystores;
            }

            Console.WriteLine($"you have chosen {stores[storeindex]}");
            MenuFactory.GetMenu("beer").Start(stores[storeindex]);
            goto saystores;
            end:
            Console.WriteLine("bye");

            
            
           
           

            
            // bool mu = true;
            // do 
            // {    
            //      Console.WriteLine("\n[0] view stores");
            //      Console.WriteLine("[1] order");
            //      Console.WriteLine("[2] Add store (no longer used)");
            //      Console.WriteLine("[x] LogOut\n");

            //     string input = Console.ReadLine();
            //     switch (input)
            //     {
            //         case "0" : List<Store> stores = _bl.GetAllStores();
            //         for(int i = 0; i < stores.Count; i++)
            //         {
            //             Console.WriteLine(stores[i]);
            //         }
            //         break;

            //         case "1" : //Console.WriteLine(beer.Info());
            //         Console.WriteLine("here you go :)");
            //         MenuFactory.GetMenu("beer").Start();
            //         break;

            //         case "2" : Console.Write("Store Name: ");
            //         string Name = Console.ReadLine();
            //         Console.Write("Store City: ");
            //         string City = Console.ReadLine();
            //         Store test = new Store(Name, City);
            //         Console.WriteLine(Name + " " + test.City);
            //         //_bl.AddStore(test);
            //         break;

            //         case "x" : Console.WriteLine("bye");
            //         mu = false;
            //         break;
                    
            //         default: Console.WriteLine("huh??");
            //         break;
            //     }
            // } while (mu);
        
       }
    }
}