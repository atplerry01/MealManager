using MealManager.Api.Models.Account;
using MealManager.Api.Models.Lookup;

namespace MealManager.Api.Models.Transact
{
    public class DepartmentMealProfiling
    {
        public int Id { get; set; }
        public Department Department { get; set; }
        public MealAssignment MealAssignment { get; set; }
        
    }
}