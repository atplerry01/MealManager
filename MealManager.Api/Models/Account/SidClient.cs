using System.Collections.Generic;
using System.Collections.ObjectModel;
using MealManager.Api.Models.Common;

namespace MealManager.Api.Models.Account
{
    public class SidClient : BaseEntity
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
    }
}