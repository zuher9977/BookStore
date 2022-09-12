using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task.Models
{
    public class ApplicationUser: IdentityUser
    {
        public String Name { set; get; }
    }
}
