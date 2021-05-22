
using Microsoft.EntityFrameworkCore;
using PizzaSite.Data.Repositories.Abstract;
using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.EntityFramework
{
    public class EFComponentsRepository : IComponentItemsRepository
    {
        private readonly ApplicationDbContext context;

        public EFComponentsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Component> GetComponentsItems()
        {
            return context.Component;
        }

        public Component GetComponentsItemById(Guid id)
        {
            return context.Component.FirstOrDefault(x => x.Id == id);
        }

        public void SaveComponentsItem(Component entity)
        {
            context.Entry(entity).State = EntityState.Added;// объект будет добавлен как новый
            context.SaveChanges();
        }

        public void DeleteComponentsItem(string id)
        {
            context.Component.Remove(new Component() { Id = Guid.Parse(id) });
            context.SaveChanges();
        }

    }
}
