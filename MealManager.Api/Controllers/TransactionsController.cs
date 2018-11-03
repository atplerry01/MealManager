using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealManager.Api.Models.Transact;
using MealManager.Api.Persistence;
using MealManager.Api.ViewModel.Transact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealManager.Api.Controllers
{
    [Route("api/meal/transactions")]
    public class TransactionsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public TransactionsController(IMapper mapper, ApplicationDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<MealTransactionModel>> GetMealTransactions(string rangeType, [FromQuery]string startDate, [FromQuery]string endDate)
        {
            var startDateStr = "";
            var endDateStr = "";

            DateTime start = new DateTime();
            DateTime end = new DateTime();

            int first, last = new int();
            int month, year = new int();

            if (rangeType == "ThisMonth")
            {
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;

                first = 1;
                last = DateTime.DaysInMonth(year, month);

                var raw1 = year + "-" + month + "-" + first;
                var raw2 = year + "-" + month + "-" + last;

                start = DateTime.Parse(raw1);
                end = DateTime.Parse(raw2);
            }
            else if (rangeType == "LastMonth")
            {
                month = DateTime.Now.Month - 1;
                year = DateTime.Now.Year;

                first = 1;
                last = DateTime.DaysInMonth(year, month);

                var raw1 = year + "-" + month + "-" + first;
                var raw2 = year + "-" + month + "-" + last;

                start = DateTime.Parse(raw1);
                end = DateTime.Parse(raw2);

            }
            else if (rangeType == "DateRange")
            {
                System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
                startDateStr = Convert.ToDateTime(startDate, ci.DateTimeFormat).ToString("d");
                endDateStr = Convert.ToDateTime(endDate, ci.DateTimeFormat).ToString("d");

                var startTime = TimeSpan.Parse("00:00:00");
                var endTime = TimeSpan.Parse("23:59:59");

                DateTime mealStartDate = Convert.ToDateTime(startDateStr) + startTime;
                DateTime mealEndDate = Convert.ToDateTime(endDateStr) + endTime;

                start = mealStartDate;
                end = mealEndDate;
            }
            else
            {
                // start = DateTime.Now;
                // end = DateTime.Now;
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;

                first = 1;
                last = DateTime.DaysInMonth(year, month);

                var raw1 = year + "-" + month + "-" + first;
                var raw2 = year + "-" + month + "-" + last;

                start = DateTime.Parse(raw1);
                end = DateTime.Parse(raw2);
            }

            var entity = await context.MealTransactions
                .Include(u => u.User)
                .Include(m => m.Menu)
                .Include(u => u.UserMealProfiling)
                .Where(p => p.CreatedOn >= start && p.CreatedOn <= end).ToListAsync();

            return mapper.Map<IEnumerable<MealTransaction>, IEnumerable<MealTransactionModel>>(entity);
        
        }


        // All MealTransaction
        // Today Transaction
        // This Month Transaction
        // Last Month Transaction
        // DateRange Transaction

    }
}