using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mods;

namespace Bus
{
    public interface IBL
    {   
        /// <summary>
        /// Adds a customer to customer table
        /// </summary>
        /// <param name="custo"></param>
        /// <returns></returns>
        Customer AddCustomer(Customer custo);

        /// <summary>
        /// Returns a list of all customers
        /// </summary>
        /// <returns></returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// Returns a list of all stores
        /// </summary>
        /// <returns></returns>
        List<Store> GetAllStores();

        /// <summary>
        /// Returns a list of all orders
        /// </summary>
        /// <returns></returns>
        List<Order> GetAllOrders();

        /// <summary>
        /// Returns a list of all beers belonging to a given store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        List<Beer> GetAllBeers(Store store);

        /// <summary>
        /// Returns a list of all beers
        /// </summary>
        /// <returns></returns>
        List<Beer> GetAllBeers();

        /// <summary>
        /// Adds an order given an order to add and the id of the customer making the order
        /// </summary>
        /// <param name="ordo"></param>
        /// <param name="customerid"></param>
        /// <returns></returns>
        Order AddOrder(Order ordo, int customerid);

        /// <summary>
        /// Updates the inventory of a given beer by a given amount
        /// </summary>
        /// <param name="toadd"></param>
        /// <param name="ivbeer"></param>
        /// <returns></returns>
        Beer UpdateInventory(int toadd, Beer ivbeer);

        /// <summary>
        /// returns true if id has not been used yet
        /// </summary>
        /// <param name="testid"></param>
        /// <returns></returns>
        bool IsCustomerIdUnique(int testid);

        /// <summary>
        /// Returns list of id's for a given name since multiple customers can have the same name
        /// </summary>
        /// <param name="testname"></param>
        /// <returns></returns>
        List<int> DoesCustomerNameExist(string testname);
    }
}