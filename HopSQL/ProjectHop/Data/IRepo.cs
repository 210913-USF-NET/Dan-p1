using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mods;

namespace Data
{
    public interface IRepo
    {
        Customer AddCustomer(Customer custo);

        List<Customer> GetAllCustomers();

        List<Store> GetAllStores();

        List<Beer> GetAllBeers(Store store);

        List<Beer> GetAllBeers();

        List<Order> GetAllOrders();

        Order AddOrder(Order ordo, int custoindex);

        Beer UpdateInventory(int toadd, Beer ivbeer);

        
    }
}