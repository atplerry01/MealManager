using MealManager.Api.Models.Account;

namespace MealManager.Api.Models.Transact
{
    public class UserMealProfiling
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public DepartmentMealProfiling DepartmentMealProfiling { get; set; }
        
    }
}