using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mods;
//using Entity = Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DBRepo : IRepo
    {
        private HCDBContext _context;

        public DBRepo(HCDBContext context)
        {
            _context = context;
        }

        public Customer AddCustomer(Customer custo)
        {
            Customer custotoadd = new Customer(){
                Name = custo.Name,
                Code = custo.Code,
                IsManager = custo.IsManager
            };

            _context.Add(custotoadd);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return custo;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(customer => new Mods.Customer() {
                Id = customer.Id,
                Name = customer.Name,
                Code = customer.Code,
                IsManager = (bool)customer.IsManager

            }).ToList();

        }

        public List<Store> GetAllStores()
        {
            return _context.Stores.Select(store => new Store() {
                Id = store.Id,
                Name = store.Name,
                City = store.City    
            }).ToList();
        }

        public List<Beer> GetAllBeers(Store store)
        {

            //var pe = (decimal)_context.Inventories.Where(invo => invo.BeersId == beer.Id).Select(p => p.Price);

            return _context.Beers.Where(beero => beero.store.Id == store.Id).Select(beer => new Beer() {
                Id = beer.Id,
                Name = beer.Name,
                Price = (decimal)_context.Inventories.Where(invo => invo.BeersId == beer.Id).Select(p => p.Price).ToArray()[0],
                Stock = (int)_context.Inventories.Where(invo => invo.BeersId == beer.Id).Select(s => s.Stock).ToArray()[0],
                storeId = beer.storeId

            }).ToList();
        }

        public List<Beer> GetAllBeers()
        {

            //var pe = (decimal)_context.Inventories.Where(invo => invo.BeersId == beer.Id).Select(p => p.Price);

            return _context.Beers.Select(beer => new Beer() {
                Id = beer.Id,
                Name = beer.Name,
                Price = (decimal)_context.Inventories.Where(invo => invo.BeersId == beer.Id).Select(p => p.Price).ToArray()[0],
                Stock = (int)_context.Inventories.Where(invo => invo.BeersId == beer.Id).Select(s => s.Stock).ToArray()[0],
                storeId = beer.storeId
            }).ToList();
        }

        public Order AddOrder(Order ordo, int custoindex)
        {
            
            LineItem linotoadd = new LineItem() {
                Quantity = ordo.Quantity,
                BeersId = ordo.SelectedBeer.Id,
                BeerId = ordo.SelectedBeer.Id
                //Beer = ordo.SelectedBeer
            };

            _context.Add(linotoadd);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            Order ordotoadd = new Order() {
                CustomerId = custoindex + 1,
                LineItemId = linotoadd.Id,
                Date = DateTime.Today,
                SelectedBeerId = ordo.SelectedBeer.Id,
                Quantity = ordo.Quantity,
                CustomerIndex = custoindex,
                StoresId = ordo.SelectedBeer.storeId
            };

            _context.Add(ordotoadd);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();


             System.Console.WriteLine("updating inv");
            Inventory invotoupdate2 = new Inventory() {
                Id = _context.Inventories.Where(invo => invo.BeersId == linotoadd.BeersId).Select(ii => ii.Id).ToArray()[0],
                Price = ordo.SelectedBeer.Price,
                Stock = ordo.SelectedBeer.Stock - ordo.Quantity,
                BeersId = linotoadd.BeersId

            };

            _context.Inventories.Update(invotoupdate2);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            Console.WriteLine("Order Successful\n");
            return ordo;
        }

        public List<Order> GetAllOrders()
        {
            List<Beer> obeers = GetAllBeers();

            //Mods.Beer storebeer =
            return _context.Orders.Select(ordo => new Order() {
                Id = ordo.Id,
                Date = ordo.Date,
                Quantity = (int)_context.LineItems.Where(lino => lino.Id == ordo.LineItem.Id).Select(q => q.Quantity).ToArray()[0],
                SelectedBeer = obeers[(int)_context.LineItems.Where(lino => lino.Id == ordo.LineItem.Id).Select(b => b.BeersId).ToArray()[0] - 1],
                CustomerIndex = ordo.Customer.Id - 1,
                StoresId = (int)_context.Orders.Where(sto => sto.Id == ordo.Id).Select(i => i.SelectedBeer.store.Id).ToArray()[0], //i.beer or lineitem.beer is null
                CustomerId = ordo.CustomerId,
                LineItemId = ordo.LineItemId

            }).ToList();
        }

        public Mods.Beer UpdateInventory(int toadd, Mods.Beer ivbeer)
        {
            System.Console.WriteLine("updating inv");
            Inventory invotoupdate = new Inventory() {
                Id = _context.Inventories.Where(invo => invo.BeersId == ivbeer.Id).Select(ii => ii.Id).ToArray()[0],
                Price = ivbeer.Price,
                Stock = ivbeer.Stock + toadd,
                BeersId = ivbeer.Id

            };

            _context.Inventories.Update(invotoupdate);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return ivbeer;
        }
        
    }
}