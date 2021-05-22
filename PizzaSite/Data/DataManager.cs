using PizzaSite.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Data
{
    public class DataManager
    {
        public IDrinksItemsRepository Drinks { get; set; }
        public IPizzaItemsRepository Pizza { get; set; }
        public ISaladItemsRepository Salad { get; set; }
        public IComponentItemsRepository Component { get; set; }

        public DataManager(IDrinksItemsRepository DrinksRepository, IPizzaItemsRepository PizzaRepository,
            ISaladItemsRepository SaladRepository,IComponentItemsRepository ComponentRepository)
        {
            Drinks = DrinksRepository;
            Pizza = PizzaRepository;
            Salad = SaladRepository;
            Component = ComponentRepository;
        }
    }
}
