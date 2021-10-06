using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bus;
using Mods;
using System.Diagnostics;

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

        // Get beerlist for store
        public ActionResult Beer(int stoid)
        {
            List<Store> storos = _bl.GetAllStores();
            Debug.WriteLine(stoid);
            List<Beer> stobeers = _bl.GetAllBeers(storos[stoid - 1]);
            return View(stobeers);
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
    }
}
