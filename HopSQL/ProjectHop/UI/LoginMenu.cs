using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mods;
using Bus;

namespace UI
{
    public class LoginMenu : IMenu
    {
        private IBL _bl;

        public LoginMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start(Store store){}

        public void Start()
        {
            bool inswitch = true;
            do
            {
                Console.WriteLine("[0] login");
                Console.WriteLine("[1] new customer");
                Console.WriteLine("[x] exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0" : Login();
                    break;

                    case "1" : NewCustomer();
                    break;

                    case "x" : inswitch = false;
                    break;
                    
                    default: Console.WriteLine("huh?");
                    break;
                }
            } while (inswitch);
        }


        private void Login()
        {
            loginputname:
            Console.Write("Name: ");
            string tname = Console.ReadLine();

            List<int> ids = _bl.DoesCustomerNameExist(tname);
            if (ids.Count < 1)
            {
                Console.WriteLine($"Name: {tname} does not exist");
                goto loginputname;
            }

            loginputid:
            Console.Write("ID: ");
            string stringid = Console.ReadLine();
            int tid;

            if (!int.TryParse(stringid, out tid))
            {
                Console.WriteLine("IDs contain only numbers");
                goto loginputid;
            }

            bool match = false;
            for(int i = 0; i < ids.Count; i++)
            {
                if(ids[i] == tid)
                {
                    match = true;
                    break;
                }
            }

            if(!match)
            {
                Console.WriteLine("ID does not match Name's ID");
                goto loginputid;
            }


            
            Console.WriteLine("Logging in as " + tname + "...\n...");
            Console.WriteLine("Login successful");

            //checking if manager
            List<Customer> custs = _bl.GetAllCustomers();
            bool mana = false;
            for(int i = 0; i < custs.Count; i++)
            {
                if(custs[i].Code == tid)
                {
                    if (custs[i].IsManager)
                    {
                        mana = true;
                        break;
                    }
                }
            }
            if(mana)
            {
                MenuFactory.GetMenu("manager").Start();
            }
            MenuFactory.GetMenu("main").Start();
        }

        private void NewCustomer()
        {
            Console.WriteLine("Making new customer ...");
            Customer newCusto = new Customer();

            Console.Write("\nname: ");

            string name = Console.ReadLine();

            inputid:
            Console.Write("\ncustomer id: ");

            string idstring = Console.ReadLine();

            int id;
            bool isint = int.TryParse(idstring, out id);

            if (isint)
            {
                if (_bl.IsCustomerIdUnique(id))
                {
                    newCusto.Name = name;
                    newCusto.Code = id;

                    _bl.AddCustomer(newCusto);

                    Console.WriteLine($"New customer {newCusto.Name} created");
                }
                else
                {
                    Console.WriteLine($"id: {id} is already in use\n try again");
                    goto inputid;
                }

            }
            else
            {
                Console.WriteLine($"id: {idstring} must contain only numbers\n try again");
                goto inputid;
            }

        }
    }
}