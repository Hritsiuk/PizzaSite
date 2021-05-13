using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
    }
}
