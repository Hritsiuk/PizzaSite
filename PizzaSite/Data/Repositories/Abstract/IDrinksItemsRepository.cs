using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.Abstract
{
    public interface IDrinksItemsRepository
    {
        IQueryable<Drinks> GetDrinksItems();
        Drinks GetDrinksItemById(Guid id);
        void SaveDrinksItem(Drinks entity);
        void DeleteDrinksItem(string id);
    }
}
