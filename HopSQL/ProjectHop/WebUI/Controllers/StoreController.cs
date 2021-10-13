using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bus;
using Mods;
using System.Diagnostics;
using Serilog;

namespace WebUI.Controllers
{
    public class StoreController : Controller
    {
        private IBL _bl;
       
        public StoreController(IBL bl)
        {
            _bl = bl;
        }
        // GET: StoreController
        public ActionResult Index()
        {
            List<Store> allStoro = _bl.GetAllStores();
            return View(allStoro);
        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [ActionName("Beer2")]
        public ActionResult Beer()
        {
            Debug.WriteLine("inside beer 2 action");
            List<Store> storos = _bl.GetAllStores();

            List<Beer> stobeers = new List<Beer>();
            if (Request.Cookies["StoreCookie"] != null && Request.Cookies["StoreCookie"] != "")
            {
                int storeid = int.Parse(Request.Cookies["StoreCookie"]);
                Debug.WriteLine(storeid);
                stobeers = _bl.GetAllBeers(storos[storeid - 1]);
                return View("Beer", stobeers);
            }

            stobeers = _bl.GetAllBeers();
            
            return View("Beer", stobeers);
        }
        // Get beerlist for store
        [ActionName("Beer")]
        public ActionResult Beer(int stoid)
        {
            Response.Cookies.Append("StoreCookie", $"{stoid}");
            List<Store> storos = _bl.GetAllStores();
            
            List<Beer> stobeers = new List<Beer>();
            //if (Request.Cookies["StoreCookie"] != null && Request.Cookies["StoreCookie"] != "")
            //{
            //    int storeid = int.Parse(Request.Cookies["StoreCookie"]);
            //    Debug.WriteLine(storeid);
            //    stobeers = _bl.GetAllBeers(storos[storeid - 1]);
            //    return View(stobeers);
            //}
            
            stobeers = _bl.GetAllBeers(storos[stoid - 1]);
            return View(stobeers);
        }

        // Get orders for store
        public ActionResult ViewOrders(int stoid)
        {
            List<Order> ordos = _bl.GetAllOrders();
            List<Order> stordos = new List<Order>();

            foreach(var ord in ordos)
            {
                if (ord.StoresId == stoid)
                {
                    stordos.Add(ord);
                }
            }
            ViewData["Manager"] = Request.Cookies["ManagerCookie"];
            return View("../Order/Index", stordos);
        }
       
        

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store store)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Editbeer/5
        public ActionResult EditBeer(int BeerId)
        {
           
            List<Beer> beero = _bl.GetAllBeers();
            ViewData["Manager"] = Request.Cookies["ManagerCookie"];
            return View(beero[BeerId - 1]);
        }

        // POST: StoreController/Editbeer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBeer(int Id, Beer beer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    List<Beer> beeros = _bl.GetAllBeers();
                    Beer beertochange = beeros[Id - 1];

                    int toadd = beer.Stock;

                    Debug.WriteLine(beer);
                    Debug.WriteLine($"id = {Id}");

                    _bl.UpdateInventory(toadd, beertochange);
                    Log.Information("Inventory updated");

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: StoreController/Delete/5
        public ActionResult Order(int BeerId)
        {
            int custoid = 0;
            if (int.TryParse(Request.Cookies["IdCookie"], out custoid))
            {
                if (custoid == 0)
                {
                    Debug.WriteLine($"inside of custiod = 0" );
                    return RedirectToAction("Index", "Customer");
                }

                Debug.WriteLine($"custoid = {custoid}");
            }
            else
            {
                Debug.WriteLine($"Parse failed custoid = {custoid}");
                Debug.WriteLine($"cookie = {Request.Cookies["IdCookie"]}");
                return RedirectToAction("Index", "Customer");
            }
            Response.Cookies.Append("BeerCookie", $"{BeerId}");
            return View();
        }

        // POST: StoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(Order order)
        {
            int custoid = 0;
            if (int.TryParse(Request.Cookies["IdCookie"], out custoid))
            {
                if (custoid == 0)
                {
                    return RedirectToAction("Index", "Customer");
                }
            }
            else
            {
                return RedirectToAction("Index", "Customer");
            }

            try
            {
                if (ModelState.IsValid)
                {
                     
                    if(int.TryParse(Request.Cookies["IdCookie"], out custoid))
                    {
                        if (custoid == 0)
                            custoid = 1 / custoid;
                    }
                    List<Beer> beeros = _bl.GetAllBeers();


                    int BeerId;
                    if (int.TryParse(Request.Cookies["BeerCookie"], out BeerId))
                    {
                        if (BeerId == 0)
                            BeerId = 1 / BeerId;
                    }
                    int beerindex = BeerId - 1;
                    order.SelectedBeer = beeros[beerindex];
                    Debug.WriteLine("adding order");
                    _bl.AddOrder(order, custoid);
                    Debug.WriteLine("Order added");
                    Log.Information("Order added");

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
