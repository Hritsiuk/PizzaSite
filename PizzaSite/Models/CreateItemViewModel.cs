using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class CreateItemViewModel
    {
        public string name { get; set; }
        public double price { get; set; }
        public string img { get; set; }
        public string size { get; set; }
        public Component components { get; set; }

    }
}
