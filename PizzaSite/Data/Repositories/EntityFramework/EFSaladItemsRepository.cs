using Microsoft.EntityFrameworkCore;
using PizzaSite.Data.Repositories.Abstract;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.EntityFramework
{
    public class EFSaladItemsRepository : IFoodItemsRepository
    {
        private readonly ApplicationDbContext context;

        public EFSaladItemsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Food> GetFoodItems()
        {
            return context.Salads;
        }

        public Food GetFoodItemById(Guid id)
        {
            return context.Salads.FirstOrDefault(x => x.Id == id);
        }

        public void SaveFoodItem(object entity)
        {
            Salad p = (Salad)entity;
            context.Entry(p).State = EntityState.Added;// объект будет добавлен как новый
            context.SaveChanges();
        }

        public void DeleteFoodItem(string id)
        {
            context.Salads.Remove(new Salad() { Id = Guid.Parse(id) });
            context.SaveChanges();
        }

    }
}
