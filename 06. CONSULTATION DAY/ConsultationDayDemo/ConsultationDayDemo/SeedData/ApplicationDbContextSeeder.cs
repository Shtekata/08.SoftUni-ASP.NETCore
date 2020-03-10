using ConsultationDayDemo.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ConsultationDayDemo.SeedData
{
    public class ApplicationDbContextSeeder
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public ApplicationDbContextSeeder(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            this.dbContext = dbContext;
        }
        public async Task SeedDataAsync()
        {
            await SeedUsersAsync();
            await SeedRolesAsync();
            await SeedUserToRolesAsync();
        }

        private async Task SeedUserToRolesAsync()
        {
            var user = await userManager.FindByNameAsync("Shtekata");
            var role = await roleManager.FindByNameAsync("Admin");

            var exists = dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);
            
            if (exists)
            {
                return;
            }

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string> 
            { 
                UserId = user.Id, 
                RoleId = role.Id 
            });

            await dbContext.SaveChangesAsync();
        }

        private async Task SeedRolesAsync()
        {
            var role = await roleManager.FindByNameAsync("Admin");

            if (role != null)
            {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin",
            });
        }

        private async Task SeedUsersAsync()
        {
            var user = await userManager.FindByNameAsync("Shtekata");

            if (user != null)
            {
                return;
            }

            await userManager.CreateAsync(new IdentityUser
            {
                UserName = "Shtekata",
                Email = "gesheval@gmail.com",
                EmailConfirmed = true,
            },
            "aA@111");
        }
    }
}
