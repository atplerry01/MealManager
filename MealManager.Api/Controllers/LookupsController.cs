using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MealManager.Api.Models.Lookup;
using MealManager.Api.Models.Transact;
using MealManager.Api.Persistence;
using MealManager.Api.ViewModel.Lookup;
using MealManager.Api.ViewModel.Transact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealManager.Api.Controllers
{
    [Route("api/lookups")]
    public class LookupsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public LookupsController(IMapper mapper, ApplicationDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("Menus")]
        public async Task<IEnumerable<MenuModel>> GetMenus()
        {
            var results = await context.Menus.ToListAsync();
            return mapper.Map<IEnumerable<Menu>, IEnumerable<MenuModel>>(results);
        }

        [HttpGet("department/profiling")]
        public async Task<IEnumerable<DepartmentMealProfilingModel>> GetDepartmentProfilings()
        {
            var entity = await context.DepartmentMealProfilings
                .Include(u => u.Department)
                .Include(d => d.MealAssignment)
                .ToListAsync();

            return mapper.Map<IEnumerable<DepartmentMealProfiling>, IEnumerable<DepartmentMealProfilingModel>>(entity);
        }


    }
}