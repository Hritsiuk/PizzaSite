using PizzaSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data.Repositories.Abstract
{
    public interface IComponentItemsRepository
    {
         IQueryable<Component> GetComponentsItems();
        Component GetComponentsItemById(Guid id);
        void SaveComponentsItem(Component entity);
        void DeleteComponentsItem(string id);
    }
}
