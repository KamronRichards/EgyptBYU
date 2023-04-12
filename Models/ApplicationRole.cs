using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptBYU.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }

}
