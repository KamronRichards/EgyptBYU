using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// sets fields for the users to do RBAC

namespace EgyptBYU.Models
{
    public class UserRole
    {
        public string UserId { get; set; }
        public string RoleName { get; set;}
    }
}
