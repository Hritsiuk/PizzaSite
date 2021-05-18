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

        public ItemController(ApplicationDbContext context)
        {
            bd = context;
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
                if(model.idproductcategory==1)
                dataManager.Items.SaveFoodItem(new Pizza { Id = model.Id, name = model.name, price=model.price,img = model.img,size=model.size,components=model.components});
                else if (model.idproductcategory == 0)
                    dataManager.Items.SaveFoodItem(new Salad { Id = model.Id, name = model.name, price = model.price, img = model.img, components = model.components });
                if (model.idproductcategory == -1)
                    dataManager.Items.SaveFoodItem(new Drinks { Id = model.Id, name = model.name, price = model.price, img = model.img});


                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
