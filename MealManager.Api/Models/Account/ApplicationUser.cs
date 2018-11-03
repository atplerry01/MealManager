using Microsoft.AspNetCore.Identity;
using MealManager.Api.Models.Account;

namespace MealManager.Api.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEnabled { get; set; }
    }
}