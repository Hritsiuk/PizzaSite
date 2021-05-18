using Microsoft.EntityFrameworkCore;
using PizzaSite.Data.Repositories.Abstract;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.EntityFramework
{
    public class EFDrinksItemsRepository : IFoodItemsRepository
    {
        private readonly ApplicationDbContext context;

        public EFDrinksItemsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Food> GetFoodItems()
        {
            return context.Drinks;
        }

        public Food GetFoodItemById(Guid id)
        {
            return context.Drinks.FirstOrDefault(x => x.Id == id);
        }

        public void SaveFoodItem(object entity)
        {
            Drinks p = (Drinks)entity;
            context.Entry(p).State = EntityState.Added;// объект будет добавлен как новый
            context.SaveChanges();
        }

        public void DeleteFoodItem(string id)
        {
            context.Drinks.Remove(new Drinks() { Id = Guid.Parse(id) });
            context.SaveChanges();
        }


    }
}
