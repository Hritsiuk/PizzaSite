using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using PizzaSite.Data;
using PizzaSite.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Helpers;

namespace PizzaSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db;
        private DataManager dataManager;
        public HomeController(ApplicationDbContext context,DataManager datamanager)
        {
            db = context;
            dataManager = datamanager;

          

        }

        public IActionResult Index()
        {         
            
            return View();
        }
     


        public IActionResult PizzaV()
        {

           

            return View(dataManager.Pizza.GetPizzaItems());
        }
        public IActionResult Beverages()
        {



            return View(dataManager.Drinks.GetDrinksItems());
        }

        [HttpGet]
        public IActionResult Scart()
        {
           
           List<StringValues> cookie2 = Request.Headers.Values.ToList();
            string c = "";
            foreach (StringValues item in cookie2)
            {
                if(item.ToString().Contains("username"))
                 c = item;
            }
           
            List<Food> list = new List<Food>();
            try
            {
                string c2= c.Remove(0, 9);
                Root myclass = JsonConvert.DeserializeObject<Root>(c2);
                foreach (Arr id in myclass.arr)
                {
                    switch (id.idt)
                    {
                        case 2:
                             list.Add(dataManager.Pizza.GetPizzaItemById(new Guid(id.name)));
                            break;
                        case 3:
                            list.Add(dataManager.Salad.GetSaladItemById(new Guid(id.name)));
                            break;
                        case 4:
                            list.Add(dataManager.Drinks.GetDrinksItemById(new Guid(id.name)));
                            break;
                        default:
                            break;
                    }
                   
                }

            }
            catch (Exception io)
            {
               
            }

            return View(list);
        }

        [HttpPost]
        public IActionResult Scart(Order view)
        {
            List<Food> fl = view.foods;

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
