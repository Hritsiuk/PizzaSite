using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSite.Models
{
    public class User : IdentityUser
    {

        public string Position { get; set; }

    }
}
