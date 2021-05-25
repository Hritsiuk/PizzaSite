using Microsoft.EntityFrameworkCore;
using PizzaSite.Data.Repositories.Abstract;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.EntityFramework
{
    public class EFPizzaItemsRepository : IPizzaItemsRepository
    {
        private readonly ApplicationDbContext context;

        public EFPizzaItemsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Pizza> GetPizzaItems()
        {
            return context.Pizza;
        }

        public Pizza GetPizzaItemById(Guid id)
        {
            return context.Pizza.FirstOrDefault(x => x.Id == id);
        }

        public void SavePizzaItem(Pizza entity)
        {
            context.Pizza.Add(entity);// объект будет добавлен как новый
            context.SaveChanges();
         
        }

        public void DeletePizzaItem(string id)
        {
            context.Pizza.Remove(new Pizza() { Id = Guid.Parse(id) });
            context.SaveChanges();
        }

       
    }
}
