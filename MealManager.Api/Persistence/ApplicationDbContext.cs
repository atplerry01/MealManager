using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MealManager.Api.Models;
using MealManager.Api.Models.Account;
using MealManager.Api.Persistence.Configuration;
using MealManager.Api.Models.Lookup;
using MealManager.Api.Models.Transact;

namespace MealManager.Api.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.Entity<RefreshToken>()
                .HasAlternateKey(c => c.UserId)
                .HasName("refreshToken_UserId");
            modelBuilder.Entity<RefreshToken>()
                .HasAlternateKey(c => c.Token)
                .HasName("refreshToken_Token");

            base.OnModelCreating(modelBuilder);
        }

        ///Account Sections
        public DbSet<Client> Clients { get; set; }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        ///Lookups
        public DbSet<ClientUser> ClientUsers { get; set; }


        public DbSet<Menu> Menus { get; set; }
        public DbSet<MealTransaction> MealTransactions { get; set; }
        public DbSet<DepartmentMealProfiling> DepartmentMealProfilings { get; set; }
        public DbSet<UserMealProfiling> UserMealProfilings { get; set; }


        public void InsertNew(RefreshToken token)
        {
            var tokenModel = RefreshTokens.SingleOrDefault(i => i.UserId == token.UserId);
            if (tokenModel != null)
            {
                RefreshTokens.Remove(tokenModel);
                SaveChanges();
            }
            RefreshTokens.Add(token);
            SaveChanges();
        }


    }
}