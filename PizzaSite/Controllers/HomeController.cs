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
        public IActionResult Salad()
        {

            return View(dataManager.Salad.GetSaladItems());
        }
        public IActionResult Beverages()
        {

            return View(dataManager.Drinks.GetDrinksItems());
        }

     
        public IActionResult Scart(string json)
        {

            List<FoodforTable> list2 = new List<FoodforTable>();
            
            try
            {
               
                Root myclass = JsonConvert.DeserializeObject<Root>(json);
                foreach (Arr id in myclass.arr)
                {
                    FoodforTable f = new FoodforTable();
                    switch (id.idt)
                    {
                        case 2:
                            f.food= dataManager.Pizza.GetPizzaItemById(new Guid(id.name));
                            break;
                        case 3:
                            f.food = dataManager.Salad.GetSaladItemById(new Guid(id.name));
                            break;
                        case 4:
                            f.food = dataManager.Drinks.GetDrinksItemById(new Guid(id.name));
                            break;
                        default:
                            break;
                    }
                    f.count = id.count;
                        f.total = (id.count * f.food.price);
                    if (id.componentid != "")
                    {
                        f.component = dataManager.Component.GetComponentsItemById(new Guid(id.componentid));
                        f.total +=(id.count * f.component.price);
                    }
                    
                   
                    list2.Add(f);

                }

            }
            catch (Exception io)
            {
               
            }

            return View(list2);
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
            double total = 0;
            List<FoodforTable> list2 = new List<FoodforTable>();

            try
            {

                Root myclass = JsonConvert.DeserializeObject<Root>(json2);
                foreach (Arr id in myclass.arr)
                {
                    FoodforTable f = new FoodforTable();
                    switch (id.idt)
                    {
                        case 2:
                            f.food = dataManager.Pizza.GetPizzaItemById(new Guid(id.name));
                            break;
                        case 3:
                            f.food = dataManager.Salad.GetSaladItemById(new Guid(id.name));
                            break;
                        case 4:
                            f.food = dataManager.Drinks.GetDrinksItemById(new Guid(id.name));
                            break;
                        default:
                            break;
                    }
                    f.count = id.count;
                    f.total = id.count * f.food.price;
                    total += f.total;
                    list2.Add(f);

                }

            }
            catch (Exception io)
            {

            }
            ViewBag.total = total;
            return View(list2);
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            Order temp = order;
            temp.Id = new Guid();
            db.Orders.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
