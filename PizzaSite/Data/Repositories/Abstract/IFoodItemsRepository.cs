using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.Abstract
{
    public interface IFoodItemsRepository
    {
        IQueryable<Food> GetFoodItems();
        Food GetFoodItemById(Guid id);
        void SaveFoodItem(object entity);
        void DeleteFoodItem(string id);
    }
}
