using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bus;
using Mods;


namespace WebUI.Controllers
{
    public class BeerController : Controller
    {
        private IBL _bl;

        public BeerController(IBL bl)
        {
            _bl = bl;
        }

        // GET: BeerController
        public ActionResult Index()
        {
            List<Beer> allBeero = _bl.GetAllBeers();
            return View(allBeero);
        }

        // GET: BeerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BeerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BeerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BeerController/Edit/5
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

        // GET: BeerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BeerController/Delete/5
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
