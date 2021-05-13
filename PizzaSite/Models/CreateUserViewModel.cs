using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
    }
}
