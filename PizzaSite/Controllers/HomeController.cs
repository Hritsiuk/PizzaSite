using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaSite.Data;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;



namespace PizzaSite.Controllers
{
    public class HomeController : Controller
    {
      
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

     
        public IActionResult Scart(string json)
        {
            

            List<Food> list = new List<Food>();
            try
            {
                
                Root myclass = JsonConvert.DeserializeObject<Root>(json);
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

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Checkout(string json2)
        {
          
            List<Food> list = new List<Food>();
            try
            {
                Root myclass = JsonConvert.DeserializeObject<Root>(json2);
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

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
