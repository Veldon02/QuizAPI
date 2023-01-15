using Microsoft.AspNetCore.Identity;
using QuizAPI.Data.Helpers;

namespace QuizAPI.Data
{
    public class DataInitializer
    {
        public static async Task SeedRolesToDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await _roleManager.RoleExistsAsync(UserRoles.DefaultUser))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.DefaultUser));
            }
        }
    }
}
