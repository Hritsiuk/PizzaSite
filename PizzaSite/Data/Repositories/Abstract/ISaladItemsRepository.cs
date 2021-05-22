using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.Abstract
{
    public interface ISaladItemsRepository
    {
        IQueryable<Salad> GetSaladItems();
        Salad GetSaladItemById(Guid id);
        void SaveSaladItem(Salad entity);
        void DeleteSaladItem(string id);
    }
}
