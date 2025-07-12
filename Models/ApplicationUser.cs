using Microsoft.AspNetCore.Identity;
using System;

namespace BudgetPlanner.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        // Optional: Profile picture (if you expand later)
    }
}
