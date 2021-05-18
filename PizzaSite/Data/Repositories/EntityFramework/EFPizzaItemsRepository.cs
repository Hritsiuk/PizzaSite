using Microsoft.EntityFrameworkCore;
using PizzaSite.Data.Repositories.Abstract;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.EntityFramework
{
    public class EFPizzaItemsRepository : IFoodItemsRepository
    {
        private readonly ApplicationDbContext context;

        public EFPizzaItemsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Food> GetFoodItems()
        {
            return context.Pizzas;
        }

        public Food GetFoodItemById(Guid id)
        {
            return context.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public void SaveFoodItem(object entity)
        {
            Pizza p = (Pizza)entity;
            context.Entry(p).State = EntityState.Added;// объект будет добавлен как новый
            context.SaveChanges();
        }

        public void DeleteFoodItem(string id)
        {
            context.Pizzas.Remove(new Pizza() { Id = Guid.Parse(id) });
            context.SaveChanges();
        }

       
    }
}
