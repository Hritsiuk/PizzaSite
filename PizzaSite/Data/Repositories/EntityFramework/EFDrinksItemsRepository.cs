using Microsoft.EntityFrameworkCore;
using PizzaSite.Data.Repositories.Abstract;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.EntityFramework
{
    public class EFDrinksItemsRepository : IDrinksItemsRepository
    {
        private readonly ApplicationDbContext context;

        public EFDrinksItemsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Drinks> GetDrinksItems()
        {
            return context.Drink;
        }

        public Drinks GetDrinksItemById(Guid id)
        {
            return context.Drink.FirstOrDefault(x => x.Id == id);
        }

        public void SaveDrinksItem(Drinks entity)
        {
            context.Entry(entity).State = EntityState.Added;// объект будет добавлен как новый
            context.SaveChanges();
        }

        public void DeleteDrinksItem(string id)
        {
            context.Drink.Remove(new Drinks() { Id = Guid.Parse(id) });
            context.SaveChanges();
        }


    }
}
