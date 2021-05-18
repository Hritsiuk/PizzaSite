using PizzaSite.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data
{
    public class DataManager
    {
        public IFoodItemsRepository Items { get; set; }
     

        public DataManager(IFoodItemsRepository ItemsRepository)
        {
           Items = ItemsRepository;
           
        }
    }
}
