using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mods;
using Bus;

namespace UI
{
    public class ManagerMenu : IMenu
    {
        private IBL _bl;

        public ManagerMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start(Store store){}
        public void Start(){
            System.Console.WriteLine("Manager Menu");

            bool inswitch = true;
            do
            { 
                System.Console.WriteLine("\nChoose an option\n");
                System.Console.WriteLine("[0] view location inventory");
                System.Console.WriteLine("[1] view location orders");
                System.Console.WriteLine("[2] replenish inventory");
                System.Console.WriteLine("[x] exit and procede to main menu");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0": ViewInv();
                    break;

                    case "1": ViewOrders();
                    break;

                    case "2": AddInv();
                    break;

                    case "x": inswitch = false;
                    System.Console.WriteLine("exiting manager menu");
                    break;

                    default: System.Console.WriteLine("huh?");
                    break;
                }
            }while (inswitch);
           

        }

        private void ViewInv()
        {
            System.Console.WriteLine("viewing inventory");
               saystores:
            Console.WriteLine("Select a store location");
            List<Store> stores = _bl.GetAllStores();
            for(int i = 0; i < stores.Count; i++)
            {
                Console.WriteLine("[" + i + "] " + stores[i]);
            } 
            Console.WriteLine("[x] cancel\n");
            

            string input = Console.ReadLine();

            if (input == "x")
            {
                goto end;
            }

            int storeindex;
            if (!int.TryParse(input, out storeindex))
            {
                Console.WriteLine("select store using number or input x to cancel\n");
                goto saystores;
            }

            if (storeindex < 0 || storeindex > stores.Count - 1)
            {
                Console.WriteLine($"please choose a number from 0 to {stores.Count - 1}");
                goto saystores;
            }

            Console.WriteLine($"you have chosen {stores[storeindex]}");

            List<Beer> beers = _bl.GetAllBeers(stores[storeindex]);
            foreach (Beer b in beers)
            {
                System.Console.WriteLine(b);
            }
            end:
            System.Console.WriteLine("returning to manager menu");
        }

        private void ViewOrders()
        {
            System.Console.WriteLine("viewing orders");

            saystores:
            Console.WriteLine("Select a store location");
            List<Store> stores = _bl.GetAllStores();
            for(int i = 0; i < stores.Count; i++)
            {
                Console.WriteLine("[" + i + "] " + stores[i]);
            } 
            Console.WriteLine("[x] cancel\n");
            

            string input = Console.ReadLine();

            if (input == "x")
            {
                goto end;
            }

            int storeindex;
            if (!int.TryParse(input, out storeindex))
            {
                Console.WriteLine("select store using number or input x to cancel\n");
                goto saystores;
            }

            if (storeindex < 0 || storeindex > stores.Count - 1)
            {
                Console.WriteLine($"please choose a number from 0 to {stores.Count - 1}");
                goto saystores;
            }

            Console.WriteLine($"you have chosen {stores[storeindex]}");

            List<Order> vorders = _bl.GetAllOrders();
            foreach (Order item in vorders)
            {
                if(item.StoresId == storeindex + 1)
                {
                System.Console.WriteLine(item);
                }
            }
            end: 
            System.Console.WriteLine("returning to manager menu");
        }

        private void AddInv()
        {
            System.Console.WriteLine("adding inv");

            List<Beer> beers = _bl.GetAllBeers();
            Console.WriteLine("Choose a Beer to restock:\n");
            
            for(int i = 0; i < beers.Count; i++)
            {
                Console.WriteLine("[" + i + "] " + beers[i].Name + " Stock: " + beers[i].Stock);
            }
            Console.WriteLine("[x] (Cancel)");
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
                Console.WriteLine(beers[input].Name + " Stock: " + beers[input].Stock);
                
            }
            else
            {
               Console.WriteLine("invalid input, out of range");
                goto Gettinginput;  
            }
            adding:
            System.Console.WriteLine("how many to add?");
            string sadd = Console.ReadLine();
            int toadd;

            if(!int.TryParse(sadd, out toadd))
            {
                System.Console.WriteLine("please input a number");
                goto adding;
            }

            System.Console.WriteLine($"Adding {toadd}");

            _bl.UpdateInventory(toadd, beers[input]);
            


        }
    }
}