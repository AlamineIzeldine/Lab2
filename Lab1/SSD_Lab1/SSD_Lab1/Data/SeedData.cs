using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SSD_Lab1.Models;

namespace SSD_Lab1.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            
            string[] roles = { "Supervisor", "Employee" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            
            var supervisor = new ApplicationUser
            {
                UserName = "supervisor@test.com",
                Email = "supervisor@test.com",
                FirstName = "Super",
                LastName = "Visor",
                City = "Toronto",
                EmailConfirmed = true 
            };

            if (await userManager.FindByEmailAsync(supervisor.Email) == null)
            {
                var result = await userManager.CreateAsync(supervisor, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(supervisor, "Supervisor");
                }
            }

            
            var employee = new ApplicationUser
            {
                UserName = "employee@test.com",
                Email = "employee@test.com",
                FirstName = "Em",
                LastName = "Ployee",
                City = "Hamilton",
                EmailConfirmed = true 
            };

            if (await userManager.FindByEmailAsync(employee.Email) == null)
            {
                var result = await userManager.CreateAsync(employee, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee, "Employee");
                }
            }

            
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    new Company { Name = "TechCorp", YearsInBusiness = 12, Website = "https://techcorp.com", Province = "ON" },
                    new Company { Name = "BuildIt", YearsInBusiness = 5, Website = "https://buildit.ca", Province = "BC" },
                    new Company { Name = "HealthPlus", YearsInBusiness = 20, Website = "https://healthplus.org", Province = "QC" }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
