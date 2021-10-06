using System;
using Mods;
using Data;
using System.Collections.Generic;


namespace Bus
{
    public class BL : IBL
    {
        private IRepo _repo;

        public BL(IRepo repo)
        {
            _repo = repo;
        }

        

        public List<Store> GetAllStores()
        {
            return _repo.GetAllStores();
        }

        public List<Beer> GetAllBeers(Store store)
        {
            return _repo.GetAllBeers(store);
        }

        public List<Beer> GetAllBeers()
        {
            return _repo.GetAllBeers();
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customer AddCustomer(Customer custo)
        {
            return _repo.AddCustomer(custo);
        }

        public bool IsCustomerIdUnique(int testid)
        {
            List<Customer> customers = _repo.GetAllCustomers();
            bool unique = true;

            for(int i = 0; i < customers.Count; i++)
            {
                if(testid == customers[i].Code)
                {
                    unique = false;
                    return unique;
                }
            }

            return unique;

        }

        public List<int> DoesCustomerNameExist(string testname)
        {
            List<Customer> customers = _repo.GetAllCustomers();
            List<int> idlist = new List<int>();

            for(int i = 0; i < customers.Count; i++)
            {
                if(customers[i].Name == testname)
                {
                    idlist.Add(customers[i].Code);
                }
            }

            return idlist;

        }

        public Order AddOrder(Order ordo, int customerid)
        {
            List<Customer> customers = _repo.GetAllCustomers();
            int custoindex = -1;

            for (int i = 0; i < customers.Count; i++)
            {
                if(customers[i].Code == customerid)
                {
                    custoindex = i;
                    break;
                }

                
            }
            return _repo.AddOrder(ordo, custoindex);

        }

        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public Beer UpdateInventory(int toadd, Beer ivbeer)
        {
            return _repo.UpdateInventory(toadd, ivbeer);
        }
    }
}
