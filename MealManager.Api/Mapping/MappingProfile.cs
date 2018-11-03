using AutoMapper;
using MealManager.Api.Models;
using MealManager.Api.Models.Account;
using MealManager.Api.Models.Lookup;
using MealManager.Api.Models.Transact;
using MealManager.Api.ViewModel.Account;
using MealManager.Api.ViewModel.Lookup;
using MealManager.Api.ViewModel.Transact;

namespace MealManager.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu, MenuModel>();        
            CreateMap<ApplicationUser, ApplicationUserModel>();
            CreateMap<Department, DepartmentModel>();
            CreateMap<DepartmentMealProfiling, DepartmentMealProfilingModel>();
            CreateMap<MealTransaction, MealTransactionModel>();

            // CreateMap<AccountUpdateResource, ApplicationUser>();
            // CreateMap<ClientUserModel, ClientUser>();
        }
    }
}