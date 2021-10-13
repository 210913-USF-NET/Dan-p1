using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bus;
using Mods;
using Serilog;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {

        private IBL _bl;

        public CustomerController(IBL bl)
        {
            _bl = bl;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            List<Customer> allCusto = _bl.GetAllCustomers();
            return View(allCusto);
            return View();
        }

        public ActionResult List()
        {

            ViewData["Manager"] = Request.Cookies["ManagerCookie"];
            List<Customer> allCusto = _bl.GetAllCustomers();
            return View(allCusto);
            return View();
        }

        public ActionResult Orders(int custoid)
        {
            List<Order> ordos = _bl.GetAllOrders();
            List<Order> custordos = new List<Order>();

            foreach (var ord in ordos)
            {
                if (ord.CustomerId == custoid)
                {
                    custordos.Add(ord);
                }
            }
            ViewData["Manager"] = Request.Cookies["ManagerCookie"];
            return View("../Order/Index", custordos);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Logout/5
        public ActionResult Logout()
        {

            Response.Cookies.Append("NameCookie", $"");
            Response.Cookies.Append("IdCookie", $"");
            Response.Cookies.Append("ManagerCookie", $"");

            ViewData["IdAlert"] = "Id is " + Request.Cookies["IdCookie"];
            ViewData["NameAlert"] = "Name is " + Request.Cookies["NameCookie"];
            Log.Information("Customer logged out");

            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewData["Alert"] = "";
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                bool isunique = true;
                List<Customer> custos = _bl.GetAllCustomers();
                for(int i = 0; i < custos.Count; i++)
                {
                    if(custos[i].Code == customer.Code)
                    {
                        isunique = false;
                        break;
                    }
                }

                if (isunique)
                {
                    if (ModelState.IsValid)
                    {
                        _bl.AddCustomer(customer);
                        Log.Information("New customer created");

                        return RedirectToAction(nameof(Index));
                    }
                    return View();
                }
                else
                {
                    ViewData["Alert"] = "that Id is already being used";
                    return View();//Content("<script language ='javascript' type ='text/javascript'>alert('User Id must be unique');</script>");
                }
            }
            catch
            {
                return View();
            }
        }


        // GET: CustomerController/Login
        public ActionResult Login()
        {
            ViewData["IdAlert"] = "";
            ViewData["NameAlert"] = "";
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer customer)
        {
            bool cman = false;
            bool NameExists = false;
            List<Customer> custos = _bl.GetAllCustomers();
            List<Customer> matches = new List<Customer>();
            for (int i = 0; i < custos.Count; i++)
            {
                if (custos[i].Name == customer.Name)
                {
                    NameExists = true;
                    matches.Add(custos[i]);
                    System.Diagnostics.Debug.WriteLine($"custos bool = {custos[i].IsManager}");
                }
            }
            bool IdMatch = false;
            if(NameExists)
            {
                for(int i = 0; i < matches.Count; i++)
                {
                    if(matches[i].Code == customer.Code)
                    {
                        IdMatch = true;
                        System.Diagnostics.Debug.WriteLine($"matches bool = {matches[i].IsManager}");
                        if(matches[i].IsManager)
                        {
                            cman = true;
                        }
                        break;
                    }
                }

                if (!IdMatch)
                {
                    ViewData["IdAlert"] = "Id does not match name";
                    ViewData["NameAlert"] = "Name does not match Id";
                }

            }
            if (!NameExists)
            {
                ViewData["IdAlert"] = "";
                ViewData["NameAlert"] = "Name does not exist";
            }

            if (NameExists && IdMatch)
            {
                Response.Cookies.Append("NameCookie", $"{customer.Name}");
                Response.Cookies.Append("IdCookie", $"{customer.Code}");

                if(cman)
                {
                    Response.Cookies.Append("ManagerCookie", $"true");
                }
                else
                {
                    Response.Cookies.Append("ManagerCookie", $"false");
                }

                
                System.Diagnostics.Debug.WriteLine($"manager bool = {customer.IsManager}");
                System.Diagnostics.Debug.WriteLine(Request.Cookies["ManagerCookie"]);

                ViewData["IdAlert"] = "Login Successful";
                ViewData["NameAlert"] = "";

                Log.Information("Customer logged in");


            }
            return View();

            


        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
