using Microsoft.EntityFrameworkCore;
using PizzaSite.Data.Repositories.Abstract;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.EntityFramework
{
    public class EFSaladItemsRepository : ISaladItemsRepository
    {
        private readonly ApplicationDbContext context;

        public EFSaladItemsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Salad> GetSaladItems()
        {
            return context.Salad;
        }

        public Salad GetSaladItemById(Guid id)
        {
            return context.Salad.FirstOrDefault(x => x.Id == id);
        }

        public void SaveSaladItem(Salad entity)
        {
            context.Entry(entity).State = EntityState.Added;// объект будет добавлен как новый
            context.SaveChanges();
        }

        public void DeleteSaladItem(string id)
        {
            context.Salad.Remove(new Salad() { Id = Guid.Parse(id) });
            context.SaveChanges();
        }

    }
}
