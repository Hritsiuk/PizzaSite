using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaSite.Data;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext bd;
        private readonly DataManager dataManager;

        public ItemController(DataManager data, ApplicationDbContext context)
        {
            bd = context;
            dataManager = data;
        }

        public IActionResult Create(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new CreateItemViewModel());
        }

       
        [HttpPost]
        public IActionResult Create(CreateItemViewModel model)
        {
            if (ModelState.IsValid)
            {

                Guid guid = Guid.NewGuid();
                model.Id = guid;

                if (model.idproductcategory == 1)
                    dataManager.Component.SaveComponentsItem(new Component { Id = model.Id, name = model.name, price = model.price, img = model.img});
                else if (model.idproductcategory==2)
                    dataManager.Pizza.SavePizzaItem(new Pizza { Id = model.Id, name = model.name, price=model.price,img = model.img,size=model.size,components=model.components});
                else if (model.idproductcategory == 3)
                    dataManager.Salad.SaveSaladItem(new Salad { Id = model.Id, name = model.name, price = model.price, img = model.img, components = model.components });
                else if (model.idproductcategory == 4)
                    dataManager.Drinks.SaveDrinksItem(new Drinks { Id = model.Id, name = model.name, price = model.price, img = model.img});


                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }


        [HttpGet]
        public IActionResult Detail(string? id)
        {
           

            return View(dataManager.Pizza.GetPizzaItemById(new Guid(id)));
        }


    }
}
