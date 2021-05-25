using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
     public class Order
    {
        public Guid Id { get; set; }

        public User user { get; set; }

        public List<Food> foods { get; set; }
    }
}
