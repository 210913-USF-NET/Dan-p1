// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Mods;

// namespace Data
// {
//     public sealed class RAMRepo //: IRepo
//     {
//         private static RAMRepo _instance;

//         private RAMRepo()
//         {
//             _customers = new List<Customer>()
//             {
//                 new Customer()
//                 {
//                     Code = 12354,
//                     Name = "Dan",
//                     //orders = {}
//                 }
//             };

//             _beers0 = new List<Beer>()
//             {
//                 new Beer()
//                 {
//                     Name = "Blind Pirate IPA",
//                     Stock = 40,
//                     Price = 5.00M
//                 },

//                 new Beer()
//                 {
//                     Name = "Aint that a Peach Berliner Weisse",
//                     Stock = 36,
//                     Price = 4.50M
//                 },

//                 new Beer()
//                 {
//                     Name = "Taco Tuesday Lager",
//                     Stock = 75,
//                     Price = 4.75M
//                 }
//             };

//              _beers1 = new List<Beer>()
//             {
//                 new Beer()
//                 {
//                     Name = "Night Owl Pumpkin Ale",
//                     Stock = 47,
//                     Price = 5.25M
//                 },

//                 new Beer()
//                 {
//                     Name = "Mosaic Crisp Pilsner",
//                     Stock = 26,
//                     Price = 3.50M
//                 },

//                 new Beer()
//                 {
//                     Name = "Teal Hazy IPA",
//                     Stock = 63,
//                     Price = 3.75M
//                 }
//             };

//             _orders = new List<Order>()
//             {
//                 new Order()
//                 {
//                     Date = "TestDate",
//                     Quantity = -1,
//                     CustomerIndex = -1

//                 }
//             };

//             _stores = new List<Store>()
//             {
//                 new Store()
//                 {
//                     Name = "HopCity (Krog)",

//                     City = "Atlanta",

//                     beers = _beers0
//                 },

//                 new Store()
//                 {
//                     Name = "HopCity (Barleygarden)",

//                     City = "Fayetteville",

//                     beers = _beers1
//                 }
//             };
//         } 

//         public static RAMRepo GetInstance()
//         {
//             if(_instance == null)
//             {
//                 _instance = new RAMRepo();
//             }

//             return _instance;
//         } 

//         private static List<Customer> _customers;
//         private static List<Beer> _beers0;
//         private static List<Beer> _beers1;
//         private static List<Store> _stores;
//         private static List<Order> _orders;

//         public Customer AddCustomer(Customer custo)
//         {
//             _customers.Add(custo);
//             return custo;
//         }  

//         public Order AddOrder(Order ordo, int custoindex)
//         {
//             Console.WriteLine("Inside RR.AddOrder");
//             //_customers[custoindex].AddAnOrder(ordo);
//             ordo.CustomerIndex = custoindex;
//             _orders.Add(ordo);
//             Console.WriteLine(_customers[custoindex]);
//             Console.WriteLine(ordo.GetTotal());
//             return ordo;
//         }

//         public List<Customer> GetAllCustomers()
//         {
//             return _customers;
//         }

//         public List<Beer> GetAllBeers(Store store)
//         {
//             return store.beers;
//         }

//         public List<Store> GetAllStores()
//         {
//             return _stores;
//         }

        


//     }
// }