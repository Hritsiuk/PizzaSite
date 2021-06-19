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

        public string jfoods { get; set; }

        public string adress { get; set; }

        public string phonenumber { get; set; }

        public string comment { get; set; }

        public double totalprice { get; set; }
    }
}
