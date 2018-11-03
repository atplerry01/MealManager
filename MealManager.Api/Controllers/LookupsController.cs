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

        [HttpPost("Menus")]
        public async Task<IActionResult> CreateNebu([FromBody] MenuSaveModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            Menu newProfile = await context.Menus.FirstOrDefaultAsync(u => u.Name == model.Name);

            if (newProfile != null) {
                return StatusCode(400, "Menu Already Exist");
            }

            var entity = mapper.Map<MenuSaveModel, Menu>(model);
            context.Menus.Add(entity);
            await context.SaveChangesAsync();

            entity = await context.Menus.SingleOrDefaultAsync(it => it.Id == entity.Id);
            var result = mapper.Map<Menu, MenuModel>(entity);

            return Ok(result);
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

        [HttpPost("department/profiling")]
        public async Task<IActionResult> CreateDepartmentProfile([FromBody] DepartmentMealProfilingSaveModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            DepartmentMealProfiling newProfile = await context.DepartmentMealProfilings.FirstOrDefaultAsync(u => u.DepartmentId == model.DepartmentId);

            if (newProfile != null) {
                return StatusCode(400, "Profiling already exist");
            }

            var entity = mapper.Map<DepartmentMealProfilingSaveModel, DepartmentMealProfiling>(model);
            context.DepartmentMealProfilings.Add(entity);
            await context.SaveChangesAsync();

            entity = await context.DepartmentMealProfilings
                .Include(u => u.Department)
                .Include(d => d.MealAssignment)
                .SingleOrDefaultAsync(it => it.Id == entity.Id);

            var result = mapper.Map<DepartmentMealProfiling, DepartmentMealProfilingModel>(entity);
            return Ok(result);
        }

    }
}