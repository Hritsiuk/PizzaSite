using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class Comment
    {

        public Guid Id { get; set; }
        public Guid Id_tovar { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int rating { get; set; }
    }
}
