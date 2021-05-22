using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.Abstract
{
    public interface IPizzaItemsRepository
    {
        IQueryable<Pizza> GetPizzaItems();
        Pizza GetPizzaItemById(Guid id);
        void SavePizzaItem(Pizza entity);
        void DeletePizzaItem(string id);
    }
}
