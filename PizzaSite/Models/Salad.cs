using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class Salad : Food
    {
        string composition { get; set; }
        public Component components { get; set; }
    }
}
