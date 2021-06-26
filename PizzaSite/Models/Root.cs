using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public struct Arr
    {
        public string name { get; set; }
        public int count { get; set; }
        public int idt { get; set; }
        public string componentid { get; set; }
    }

    public struct Root
    {
        public List<Arr> arr { get; set; }
    }

}
